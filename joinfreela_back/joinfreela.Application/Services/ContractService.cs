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
        private IProjectRepository _projectRepository { get; set;}
        private IMapper _mapper { get; set; }
        private IValidator<ContractRequest> _requestvalidator { get; set; }
        private IUnityOfWork _unityOfWork { get; set; }
        private IAuthService _authService { get; set; }
        public ContractService(IContractRepository contractRepository,IProjectRepository projectRepository, IMapper mapper, IValidator<ContractRequest> requestvalidator, IUnityOfWork unityOfWork,IAuthService authService) : base(contractRepository, mapper, requestvalidator, unityOfWork)
        {
            _contractRepository = contractRepository;
            _projectRepository = projectRepository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _requestvalidator = requestvalidator;
            _authService=authService;
            
            _contractRepository.AddPreQuery(query=>query.Include(co=>co.Freelancer));
            _contractRepository.AddPreQuery(query=>query.Include(co=>co.Job));
            
            var jobsByOwner = _projectRepository.Query()
                .Where(po=>po.OwnerId == _authService.AuthUser.Id)    
                .SelectMany(po=>po.Jobs);
            
            _contractRepository.AddPreQuery(query=>query.Where(co => jobsByOwner.Any(jo=>jo.Id == co.JobId)));
                    
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