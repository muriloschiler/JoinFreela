using joinfreela.Application.DTOs.Contract;
using joinfreela.Application.Exceptions;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Services.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.UnitOfWork;
using joinfreela.Domain.Models;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using AutoMapper;
using joinfreela.Application.DTOs.Payment;
using Microsoft.Extensions.Options;
using joinfreela.Application.Options;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using joinfreela.Domain.Interfaces.Services;

namespace joinfreela.Application.Services
{
    public class ContractService : BaseService<Contract, ContractRequest, ContractResponse>, IContractService
    {

        private const string PAYMENTS_PENDING_QUEUE = "PaymentsPending";
        private IContractRepository _contractRepository { get; set; }
        private IProjectRepository _projectRepository { get; set;}
        private IMapper _mapper { get; set; }
        private IValidator<ContractRequest> _requestvalidator { get; set; }
        private IValidator<PaymentRequest> _paymentRequestvalidator { get; set; }
        private IUnityOfWork _unityOfWork { get; set; }
        private IAuthService _authService { get; set; }
        private IMessageBusService _messageBusService { get; set; }
        
        
        public ContractService
            (IContractRepository contractRepository,
            IProjectRepository projectRepository, 
            IMapper mapper, 
            IValidator<ContractRequest> requestvalidator,
            IValidator<PaymentRequest> paymentRequestvalidator, 
            IUnityOfWork unityOfWork,
            IAuthService authService,
            IMessageBusService messageBusService) : base(contractRepository, mapper, requestvalidator, unityOfWork)
        {
            _contractRepository = contractRepository;
            _projectRepository = projectRepository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _requestvalidator = requestvalidator;
            _paymentRequestvalidator=paymentRequestvalidator;
            _authService=authService;
            _messageBusService = messageBusService;
            
            _projectRepository.AddPreQuery(query=>query.Where(po=>po.OwnerId == _authService.AuthUser.Id));
            _projectRepository.AddPreQuery(query=>query.Include(co=>co.Jobs).ThenInclude(jo=>jo.Nominations));

            _contractRepository.AddPreQuery(query=>query.Include(co=>co.Freelancer));
            var jobsByOwner = _projectRepository.Query()    
                .SelectMany(po=>po.Jobs);
            _contractRepository.AddPreQuery(query=>query.Where(co => jobsByOwner.Any(jo=>jo.Id == co.JobId)));
                    
        }
        
        public override async Task<ContractResponse> RegisterAsync(ContractRequest request)
        {
            await ValidateContractRequest(request);

            var contract = _mapper.Map<Contract>(request);
            await _contractRepository.RegisterAsync(contract);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<ContractResponse>(contract);
        }
    
        public override async Task<ContractResponse> UpdateAsync(int id ,ContractRequest request)
        {
            await ValidateContractRequest(request);
            var contract = await _contractRepository.GetByIdAsync(id);
            if(contract is null)
                throw new NotFoundException("Contrato não encontrado");
            _mapper.Map<ContractRequest,Contract>(request,contract);
            await _contractRepository.UpdateAsync(contract);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<ContractResponse>(contract);
        }

        public async Task RegisterPaymentAsync(PaymentRequest request)
        {
            var validationResult = await _paymentRequestvalidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new BadRequestException(validationResult);

            var payment = await PaymentInDatabase(request);
            PublicPayment(payment);
        }

        private async Task<Payment> PaymentInDatabase(PaymentRequest request)
        {
            _contractRepository.AddPreQuery(query => query.Include(co => co.Payments));
            var contract = await _contractRepository.GetByIdAsync((int)request.ContractId);
            var payment = _mapper.Map<Payment>(request);
            contract.Payments.Add(payment);
            //interaction
            await _unityOfWork.CommitChangesAsync();
            return payment;
        }

        private void PublicPayment(Payment payment)
        {
            var paymentJson = JsonSerializer.Serialize(payment);
            var paymentJsonBytes = Encoding.UTF8.GetBytes(paymentJson);
            _messageBusService.Publish(PAYMENTS_PENDING_QUEUE,paymentJsonBytes);
        }

        private async Task ValidateContractRequest(ContractRequest request)
        {
            var validationResult = await _requestvalidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new BadRequestException(validationResult);

            var job = _projectRepository.Query()
                .SelectMany(co => co.Jobs)
                .FirstOrDefault(jo => jo.Id == request.JobId);

            if (job is null)
                throw new BadRequestException("Nenhum de seus projetos contém a vaga informada");

            if (!job.Nominations.Any(no => no.FreelancerId == request.FreelancerId))
                throw new BadRequestException("O Freelancer informado não se candidatou para a vaga");
        }

    }
}