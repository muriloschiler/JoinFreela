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

namespace joinfreela.Application.Services
{
    public class ContractService : BaseService<Contract, ContractRequest, ContractResponse>, IContractService
    {
        private IContractRepository _contractRepository { get; set; }
        private IProjectRepository _projectRepository { get; set;}
        private IMapper _mapper { get; set; }
        private IValidator<ContractRequest> _requestvalidator { get; set; }
        private IValidator<PaymentRequest> _paymentRequestvalidator { get; set; }
        private IUnityOfWork _unityOfWork { get; set; }
        private IAuthService _authService { get; set; }
        private IHttpClientFactory _httpClientFactory { get; set; }
        public readonly URLPaymentsAPI _URLPaymentsAPI ;
        public ContractService
            (IContractRepository contractRepository,
            IProjectRepository projectRepository, 
            IMapper mapper, 
            IValidator<ContractRequest> requestvalidator,
            IValidator<PaymentRequest> paymentRequestvalidator, 
            IUnityOfWork unityOfWork,
            IAuthService authService,
            IHttpClientFactory httpClientFactory,
            IOptions<URLPaymentsAPI> urlPaymentsOptions) : base(contractRepository, mapper, requestvalidator, unityOfWork)
        {
            _contractRepository = contractRepository;
            _projectRepository = projectRepository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _requestvalidator = requestvalidator;
            _paymentRequestvalidator=paymentRequestvalidator;
            _authService=authService;
            _httpClientFactory=httpClientFactory;
            _URLPaymentsAPI = urlPaymentsOptions.Value;
            
            _contractRepository.AddPreQuery(query=>query.Include(co=>co.Freelancer));
            _contractRepository.AddPreQuery(query=>query.Include(co=>co.Job).ThenInclude(jo=>jo.Nominations));
            _projectRepository.AddPreQuery(query=>query.Where(po=>po.OwnerId == _authService.AuthUser.Id));

            var jobsByOwner = _projectRepository.Query()    
                .SelectMany(po=>po.Jobs);
            _contractRepository.AddPreQuery(query=>query.Where(co => jobsByOwner.Any(jo=>jo.Id == co.JobId)));
                    
        }
        
        public override async Task<ContractResponse> RegisterAsync(ContractRequest request)
        {
            await ValidationsRequest(request);

            var contract = _mapper.Map<Contract>(request);
            await _contractRepository.RegisterAsync(contract);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<ContractResponse>(contract);
        }
    
        public override async Task<ContractResponse> UpdateAsync(int id ,ContractRequest request)
        {
            await ValidationsRequest(request);
            var contract = await _contractRepository.GetByIdAsync(id);
            if(contract is null)
                throw new NotFoundException("Contrato não encontrado");
            _mapper.Map<ContractRequest,Contract>(request,contract);
            await _contractRepository.UpdateAsync(contract);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<ContractResponse>(contract);
        }

        public async Task<PaymentResponse> RegisterPaymentAsync(PaymentRequest request)
        {
            var validationResult = await _paymentRequestvalidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new BadRequestException(validationResult);

            var responseIsSuccess = await CallThePaymentAPI(request);

            if (!responseIsSuccess)
                throw new PaymentException();

            _contractRepository.AddPreQuery(query=>query.Include(co=>co.Payments));
            var contract = await _contractRepository.GetByIdAsync((int)request.ContractId);
            var payment = _mapper.Map<Payment>(request);
            contract.Payments.Add(payment);
            //interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<PaymentResponse>(payment);
        }

        private async Task<bool> CallThePaymentAPI(PaymentRequest request)
        {
            var url = $"{_URLPaymentsAPI}/api/v1/payment";

            var httpContent = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                "application/json"
            );

            var httpClient = _httpClientFactory.CreateClient("HttpPayment");
            var response = await httpClient.PostAsync(url, httpContent);

            return response.IsSuccessStatusCode;                
        }

        private async Task ValidationsRequest(ContractRequest request)
        {
            var validationResult = await _requestvalidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new BadRequestException(validationResult);

            var job = _projectRepository.Query()
                .SelectMany(po => po.Jobs)
                .FirstOrDefault(jo => jo.Id == request.JobId);

            if (job is null)
                throw new BadRequestException("Nenhum de seus projetos contém a vaga informada");

            if (!job.Nominations.Any(no => no.FreelancerId == request.FreelancerId))
                throw new BadRequestException("O Freelancer informado não se candidatou para a vaga");
        }

    }
}