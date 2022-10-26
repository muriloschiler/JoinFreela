using AutoMapper;
using joinfreela.Application.DTOs.Common;
using joinfreela.Application.DTOs.Contract;
using joinfreela.Application.DTOs.Enumerations;
using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.DTOs.Job;
using joinfreela.Application.DTOs.Nomination;
using joinfreela.Application.DTOs.Owner;
using joinfreela.Application.DTOs.Project;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Domain.Classes.Base;
using joinfreela.Domain.Models;
using joinfreela.Domain.Models.Enumerations;

namespace joinfreela.Application.Mappers
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile(IAuthService _authService)
        {
            CreateMap<ContractRequest,Contract>();
            CreateMap<JobRequest,Job>();
            CreateMap<OwnerRequest,Owner>();
            CreateMap<ProjectRequest,Project>();
            CreateMap<SkillRequest,Skill>();
            CreateMap<FreelancerRequest,Freelancer>();
            CreateMap<SeniorityViewModel,Seniority>();
            
            CreateMap<NominationRequest,Nomination>()
                .ForMember(no=>no.FreelancerId, m=>m.MapFrom(req=> _authService.AuthUser.Id));
            
            CreateMap<UserSkillRequest,UserSkill>()
                .ForMember(usk=>usk.FreelancerId,m=>m.MapFrom(req=> _authService.AuthUser.Id));
        }   
        public RequestToDomainProfile()
        {}    
    }
}