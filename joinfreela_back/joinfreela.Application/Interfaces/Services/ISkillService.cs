using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Application.Parameters;
using joinfreela.Application.Parameters.Base;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Interfaces.Services
{
    public interface ISkillService
    {
        public Task<PaginationResponse<SkillResponse>> GetAsync(BaseParameters<Skill> skillParameters);
        Task<SkillResponse> RegisterAsync(SkillRequest skillRequest);
        Task<SkillResponse> UpdateAsync(int id,SkillRequest skillRequest);
    }
}