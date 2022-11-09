using AutoMapper;
using joinfreela.Application.DTOs.Contract;
using joinfreela.Application.DTOs.Enumerations;
using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.DTOs.Job;
using joinfreela.Application.DTOs.Nomination;
using joinfreela.Application.DTOs.Owner;
using joinfreela.Application.DTOs.Payment;
using joinfreela.Application.DTOs.Project;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Application.Interfaces.Services;
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
            CreateMap<ProjectRequest,Project>()
                .ForMember(pr=>pr.OwnerId,map=>map.MapFrom(
                    req=> _authService.AuthUser.Id
                ));
            CreateMap<SkillRequest,Skill>();
            CreateMap<PaymentRequest,Payment>();
            CreateMap<FreelancerRequest,Freelancer>()
                .ForMember(fr=>fr.Skills, m=>m.MapFrom(
                    req=> _authService.AuthUser != null ? 
                        req.Skills.Select(ukr=> new UserSkill{FreelancerId = _authService.AuthUser.Id , SkillId = ukr.SkillId,Experience = ukr.Experience }) 
                        : new List<UserSkill>()
                ));
                
            CreateMap<SeniorityViewModel,Seniority>();

            CreateMap<NominationRequest,Nomination>()
                .ForMember(no=>no.FreelancerId, m=>m.MapFrom(req=> _authService.AuthUser.Id));
        }   
    }
}