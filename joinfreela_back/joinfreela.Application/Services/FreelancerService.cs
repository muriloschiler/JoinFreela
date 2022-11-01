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
        
        public FreelancerService(IAuthService authService,IFreelancerRepository freelancerRepository, IMapper mapper, IValidator<FreelancerRequest> freelancerRequestvalidator, IUnityOfWork unityOfWork) 
        : base(freelancerRepository, mapper, freelancerRequestvalidator, unityOfWork)
        {}
        
    }
}