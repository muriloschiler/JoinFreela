using AutoMapper;
using FluentValidation;
using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.Exceptions;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Services.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.UnitOfWork;
using joinfreela.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace joinfreela.Application.Services
{
    public class FreelancerService : BaseService<Freelancer, FreelancerRequest, FreelancerResponse>, IFreelancerService
    {
        private readonly IValidator<FreelancerRequest> _freelancerRequestvalidator;
        private readonly IMapper _mapper;
        private readonly IFreelancerRepository _freelancerRepository;
        private readonly ISkillRepository _skillRepository ;
        private readonly IUnityOfWork _unityOfWork;
        public readonly IAuthService _authService;
        public FreelancerService(
            IAuthService authService,
            IFreelancerRepository freelancerRepository, 
            IMapper mapper, 
            IValidator<FreelancerRequest> freelancerRequestvalidator, 
            IUnityOfWork unityOfWork,
            ISkillRepository skillRepository) 
        : base(freelancerRepository, mapper, freelancerRequestvalidator, unityOfWork)
        {
            _freelancerRequestvalidator = freelancerRequestvalidator;
            _mapper=mapper;
            _freelancerRepository=freelancerRepository;
            _skillRepository=skillRepository;
            _unityOfWork = unityOfWork;
            _authService = authService;
        }
        
        public override async Task<FreelancerResponse> RegisterAsync(FreelancerRequest request)
        {
            var validationResult = await _freelancerRequestvalidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new BadRequestException(validationResult);
            
            var freelancer = await SaveFreelancerAsync(request);
            await SaveUserSkillAsync(request, freelancer);        

            return _mapper.Map<FreelancerResponse>(freelancer);
        }

        public override async Task<FreelancerResponse> UpdateAsync(int id,FreelancerRequest request)
        {
            _freelancerRepository.AddPreQuery(query=> query.Include(fr=>fr.Skills).ThenInclude(us=>us.Skill));

            var validationResult = await _freelancerRequestvalidator.ValidateAsync(request);
            if ( ! validationResult.IsValid)
                throw new BadRequestException(validationResult);
            
            var freelancer = await _freelancerRepository.GetByIdAsync(id);
            if (freelancer is null)
                throw new NotFoundException("O id informado não existe");
            
            if(freelancer.Id != _authService.AuthUser.Id)
                throw new NotAuthorizedException();
            
            _mapper.Map<FreelancerRequest,Freelancer>(request,freelancer);
            await _freelancerRepository.UpdateAsync(freelancer);
            //interaction
            await _unityOfWork.CommitChangesAsync();
            
            return _mapper.Map<FreelancerResponse>(freelancer);
        }

        private async Task<Freelancer> SaveFreelancerAsync(FreelancerRequest request)
        {
            var freelancer = _mapper.Map<Freelancer>(request);
            await _freelancerRepository.RegisterAsync(freelancer);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return freelancer;
        }

        private async Task SaveUserSkillAsync(FreelancerRequest request,Freelancer freelancer)
        {

            List<UserSkill> userSkillsList = new List<UserSkill>();

            foreach(var skillRequest in request.Skills)
            {
                userSkillsList.Add(
                    new UserSkill { 
                    FreelancerId = freelancer.Id, 
                    SkillId = skillRequest.SkillId, 
                    Experience = skillRequest.Experience,
                    Skill = await _skillRepository.GetByIdAsync(skillRequest.SkillId)
                    }
                ); 
            }

            freelancer.Skills = userSkillsList;
            await _unityOfWork.CommitChangesAsync();
        }

    }
}