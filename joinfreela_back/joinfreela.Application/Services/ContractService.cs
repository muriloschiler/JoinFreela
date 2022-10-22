using System.Data.Entity;
using AutoMapper;
using FluentValidation;
using joinfreela.Application.DTOs.Contract;
using joinfreela.Application.Exceptions;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Services.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.UnitOfWork;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Services
{
    public class ContractService : BaseService<Contract, ContractRequest, ContractResponse>, IContractService
    {
        private IContractRepository _contractRepository { get; set; }
        private IMapper _mapper { get; set; }
        private IValidator<ContractRequest> _requestvalidator { get; set; }
        private IUnityOfWork _unityOfWork { get; set; }
        private IAuthService _authService { get; set; }
        public ContractService(IContractRepository contractRepository, IMapper mapper, IValidator<ContractRequest> requestvalidator, IUnityOfWork unityOfWork,IAuthService authService) : base(contractRepository, mapper, requestvalidator, unityOfWork)
        {
            _contractRepository = contractRepository;
            _contractRepository.AddPreQuery(query=>query.Include(co=>co.Freelancer));
            _contractRepository.AddPreQuery(query=>query.Include(co=>co.Job));
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _requestvalidator = requestvalidator;
            _authService=authService;
        }
        
        public override async Task<ContractResponse> RegisterAsync(ContractRequest request)
        {
            var validationResult = await _requestvalidator.ValidateAsync(request);
            if(!validationResult.IsValid)
                throw new BadRequestException(validationResult);

            throw new NotImplementedException();            
        }
    }
}