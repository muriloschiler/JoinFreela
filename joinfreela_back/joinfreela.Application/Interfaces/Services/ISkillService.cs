using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Application.Parameters;
using joinfreela.Application.Parameters.Base;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Interfaces.Services
{
    public interface ISkillService
    {
        public Task<PaginationResponse<SkillResponse>> GetAsync(SkillParameters baseParameters);
        public Task<SkillResponse> GetById(int id);
        public Task<SkillResponse> RegisterAsync(SkillRequest skillRequest);
        public Task<SkillResponse> UpdateAsync(int id,SkillRequest skillRequest);
        public Task<SkillResponse> DeleteAsync(int id);
    }
}