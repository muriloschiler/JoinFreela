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
        private IValidator<FreelancerRequest> _freelancerRequestvalidator {get; set; }
        private IMapper _mapper { get; set; }
        public IFreelancerRepository _freelancerRepository { get; set; }
        public IUnityOfWork _unityOfWork { get; set; }
        public FreelancerService(IAuthService authService,IFreelancerRepository freelancerRepository, IMapper mapper, IValidator<FreelancerRequest> freelancerRequestvalidator, IUnityOfWork unityOfWork) 
        : base(freelancerRepository, mapper, freelancerRequestvalidator, unityOfWork)
        {
            _freelancerRequestvalidator = freelancerRequestvalidator;
            _mapper=mapper;
            _freelancerRepository=freelancerRepository;
        }
        
        public override async Task<FreelancerResponse> RegisterAsync(FreelancerRequest request)
        {
            var validationResult = await _freelancerRequestvalidator.ValidateAsync(request);
            if( ! validationResult.IsValid)
                throw new BadRequestException(validationResult);
            
            
            var freelancer = _mapper.Map<Freelancer>(request);
            await _freelancerRepository.RegisterAsync(freelancer);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            freelancer.Skills = request.Skills.Select(skId=> new UserSkill{FreelancerId = freelancer.Id , SkillId = skId });
            await _unityOfWork.CommitChangesAsync();

            return _mapper.Map<FreelancerResponse>(freelancer);

        }
    }
}