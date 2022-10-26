using AutoMapper;
using FluentValidation;
using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Services.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.UnitOfWork;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Services
{
    public class FreelancerService : BaseService<Freelancer, FreelancerRequest, FreelancerResponse>, IFreelancerService
    {
        public FreelancerService(IFreelancerRepository repository, IMapper mapper, IValidator<FreelancerRequest> requestvalidator, IUnityOfWork unityOfWork) : base(repository, mapper, requestvalidator, unityOfWork)
        {}
    }
}