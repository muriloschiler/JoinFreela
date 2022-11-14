using AutoMapper;
using FluentValidation;
using joinfreela.Application.DTOs.Owner;
using joinfreela.Application.Exceptions;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Services.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.UnitOfWork;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Services
{
    public class OwnerService : BaseService<Owner, OwnerRequest, OwnerResponse>, IOwnerService
    {
        private IValidator<OwnerRequest> _requestValidator;
        private IOwnerRepository _ownerRepository ;
        private IAuthService _authService;
        private IMapper _mapper;
        private IUnityOfWork _unityOfWork;
        public OwnerService(IOwnerRepository ownerRepository, IMapper mapper, IValidator<OwnerRequest> requestValidator, IUnityOfWork unityOfWork,IAuthService authService) : base(ownerRepository, mapper, requestValidator, unityOfWork)
        {
            _requestValidator = requestValidator;
            _ownerRepository = ownerRepository;
            _authService=authService;
            _authService = authService;
            _unityOfWork = unityOfWork;
        }

        public override async Task<OwnerResponse> UpdateAsync(int id , OwnerRequest request)
        {
            var validationResult = await _requestValidator.ValidateAsync(request);
            if ( ! validationResult.IsValid)
                throw new BadRequestException(validationResult);
            
            var owner = await _ownerRepository.GetByIdAsync(id);
            if (owner is null)
                throw new NotFoundException("Usuário não encontrado");
            if (owner.Id != _authService.AuthUser.Id)
                throw new NotAuthorizedException();
            
            _mapper.Map<OwnerRequest, Owner>(request,owner);
            await _ownerRepository.UpdateAsync(owner);
            //interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<OwnerResponse>(owner);
        }
    }
}