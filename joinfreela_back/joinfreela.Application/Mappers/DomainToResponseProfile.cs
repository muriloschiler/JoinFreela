using AutoMapper;
using joinfreela.Application.DTOs.Contract;
using joinfreela.Application.DTOs.Enumerations;
using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.DTOs.Job;
using joinfreela.Application.DTOs.Nomination;
using joinfreela.Application.DTOs.Owner;
using joinfreela.Application.DTOs.Project;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Domain.Models;
using joinfreela.Domain.Models.Enumerations;

namespace joinfreela.Application.Mappers
{
    public class DomainToResponseProfile: Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Contract,ContractResponse>();
            CreateMap<Job,JobResponse>();
            CreateMap<Owner,OwnerResponse>();
            CreateMap<Project,ProjectResponse>();
            CreateMap<Skill,SkillResponse>();
            CreateMap<Freelancer,FreelancerResponse>();
            CreateMap<Seniority,SeniorityViewModel>();
            CreateMap<Nomination,NominationResponse>();
            CreateMap<UserSkill,SkillResponse>();
        }
    }
}