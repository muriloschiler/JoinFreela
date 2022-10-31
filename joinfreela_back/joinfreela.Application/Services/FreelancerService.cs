using AutoMapper;
using FluentValidation;
using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.Exceptions;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Services.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.UnitOfWork;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Services
{
    public class FreelancerService : BaseService<Freelancer, FreelancerRequest, FreelancerResponse>, IFreelancerService
    {
        public IValidator<FreelancerRequest> _freelancerRequestvalidator { get; set; }
        public IMapper _mapper { get; set; }
        public IAuthService _authService { get; set; }
        public IFreelancerRepository _freelancerRepository { get; set; }
        public IUnityOfWork _unityOfWork { get; set; }
        
        
        public FreelancerService(IAuthService authService,IFreelancerRepository freelancerRepository, IMapper mapper, IValidator<FreelancerRequest> freelancerRequestvalidator, IUnityOfWork unityOfWork) : base(freelancerRepository, mapper, freelancerRequestvalidator, unityOfWork)
        {
            _freelancerRequestvalidator = freelancerRequestvalidator;
            _mapper = mapper;
            _authService = authService;
            _freelancerRepository = freelancerRepository;
            _unityOfWork = unityOfWork ;
        }
        
    }
}