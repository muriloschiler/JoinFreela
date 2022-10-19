using AutoMapper;
using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Parameters;
using joinfreela.Domain.Interfaces.Repositories;

namespace joinfreela.Application.Services
{
    public class SkillService : ISkillService
    {
        public ISkillRepository _skillRepository { get; set; }
        public IMapper _mapper { get; set; }

        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<SkillResponse>> GetAsync(SkillParameters skillParameters)
        {
            return new PaginationResponse<SkillResponse>
                {
                    Skip = skillParameters.Skip,
                    Take = skillParameters.Take,
                    Data = _mapper.Map<IEnumerable<SkillResponse>>(await _skillRepository.GetAsync(skillParameters.Skip,skillParameters.Take,skillParameters.Filter()))
                };
        }
    }
}