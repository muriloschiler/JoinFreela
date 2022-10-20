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
        public SkillService(ISkillRepository _skillRepository, IMapper _mapper, IValidator<SkillRequest> _skillRequestvalidator, IUnityOfWork _unityOfWork)
        :base(_skillRepository,_mapper,_skillRequestvalidator,_unityOfWork)
        {}

        public Task<PaginationResponse<SkillResponse>> GetAsync( SkillParameters baseParameters)
        {
            throw new NotImplementedException();
        }
    }
}