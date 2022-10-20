using AutoMapper;
using FluentValidation;
using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Parameters;
using joinfreela.Application.Parameters.Base;
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
        public SkillService(ISkillRepository skillRepository, IMapper mapper, IValidator<SkillRequest> _skillRequestvalidator, IUnityOfWork unityOfWork)
        :base(skillRepository,mapper,_skillRequestvalidator,unityOfWork)
        {
            _skillRepository=skillRepository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }

        public async Task<PaginationResponse<SkillResponse>> GetAsync( SkillParameters skillParameters)
        {

            return new PaginationResponse<SkillResponse>{
                Take = skillParameters.Take,
                Skip = skillParameters.Skip,
                Count = await _skillRepository.Count(skillParameters.Filter()), 
                Data = _mapper.Map<IEnumerable<SkillResponse>>(await _skillRepository.GetAsync(skillParameters.Skip,skillParameters.Take,skillParameters.Filter()))
            };
        }
    }
}