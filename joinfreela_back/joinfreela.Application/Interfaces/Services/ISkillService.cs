using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Application.Parameters;

namespace joinfreela.Application.Interfaces.Services
{
    public interface ISkillService
    {
        public Task<PaginationResponse<SkillResponse>> GetAsync(SkillParameters skillParameters); 
    }
}