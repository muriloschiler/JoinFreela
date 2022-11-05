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
        private IValidator<FreelancerRequest> _freelancerRequestvalidator {get; set; }
        private IMapper _mapper { get; set; }
        public IFreelancerRepository _freelancerRepository { get; set; }
        public ISkillRepository _skillRepository { get; set; }
        public IUnityOfWork _unityOfWork { get; set; }
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
        }
        
        public override async Task<FreelancerResponse> RegisterAsync(FreelancerRequest request)
        {
            var validationResult = await _freelancerRequestvalidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                throw new BadRequestException(validationResult);
            
            var freelancer = await RegisterFreelancerAsync(request);
            await RegisterUserSkillAsync(request, freelancer);        

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
            
            _mapper.Map<FreelancerRequest,Freelancer>(request,freelancer);
            await _freelancerRepository.RegisterAsync(freelancer);
            //interaction
            await _unityOfWork.CommitChangesAsync();
            
            return _mapper.Map<FreelancerResponse>(freelancer);
                
            
        }

        private async Task<Freelancer> RegisterFreelancerAsync(FreelancerRequest request)
        {
            var freelancer = _mapper.Map<Freelancer>(request);
            await _freelancerRepository.RegisterAsync(freelancer);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return freelancer;
        }

        private async Task RegisterUserSkillAsync(FreelancerRequest request,Freelancer freelancer)
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