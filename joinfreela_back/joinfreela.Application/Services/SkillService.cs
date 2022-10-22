using AutoMapper;
using FluentValidation;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Application.Exceptions;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Services.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.UnitOfWork;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Services
{
    public class SkillService : BaseService<Skill,SkillRequest,SkillResponse>, ISkillService
    {
        public ISkillRepository _skillRepository { get; set; }
        public IMapper _mapper { get; set; }
        public IUnityOfWork _unityOfWork { get; set; }
        public IValidator<SkillRequest> _skillRequestvalidator { get; set; }
        public SkillService(ISkillRepository skillRepository, IMapper mapper, IValidator<SkillRequest> skillRequestvalidator, IUnityOfWork unityOfWork)
        :base(skillRepository,mapper,skillRequestvalidator,unityOfWork)
        {
            _skillRepository=skillRepository;
            _mapper = mapper;
            _skillRequestvalidator = skillRequestvalidator;
            _unityOfWork = unityOfWork;
        }

        public override async Task<SkillResponse> RegisterAsync(SkillRequest request)
        {
            var validationResult = await _skillRequestvalidator.ValidateAsync(request);
            if( ! validationResult.IsValid)
                throw new BadRequestException(validationResult);
            
             var skill = _mapper.Map<Skill>(request);
            
            await _skillRepository.RegisterAsync(skill);
            //Interaction
            await _unityOfWork.CommitChangesAsync();
            return _mapper.Map<SkillResponse>(skill);
        }
    
    }
}