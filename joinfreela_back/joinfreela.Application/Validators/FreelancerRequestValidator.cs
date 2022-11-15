using System.Data.Entity;
using FluentValidation;
using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.Validators.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Validators
{
    public class FreelancerRequestValidator: BaseUserRequestValidator<FreelancerRequest,Freelancer>
    {
        public FreelancerRequestValidator(ISkillRepository _skillRepository,IFreelancerRepository _freelancerRespositry): base(_freelancerRespositry)
        {
            RuleForEach(fr=>fr.Skills)
                .Must(usr => _skillRepository.Query().Any(sk=>sk.Id==usr.SkillId))
                .WithMessage("A Skill informada não existe");
        }
    }
}