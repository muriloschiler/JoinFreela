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
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<ContractRequest,Contract>();
            CreateMap<JobRequest,Job>();
            CreateMap<OwnerRequest,Owner>();
            CreateMap<ProjectRequest,Project>();
            CreateMap<SkillRequest,Skill>();
            CreateMap<FreelancerRequest,Freelancer>();
            CreateMap<SeniorityViewModel,Seniority>();
            
            //CreateMap<NominationRequest,Nomination>();
            //CreateMap<SkillRequest,UserSkill>();
        }
    }
}