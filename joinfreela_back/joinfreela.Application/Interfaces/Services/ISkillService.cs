using joinfreela.Application.DTOs.Api;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Application.Interfaces.Services.Base;
using joinfreela.Application.Parameters;
using joinfreela.Application.Parameters.Base;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Interfaces.Services
{
    public interface ISkillService : IBaseService<Skill,SkillRequest,SkillResponse>
    {}
}