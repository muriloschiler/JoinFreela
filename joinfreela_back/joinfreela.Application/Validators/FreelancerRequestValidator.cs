using System.Data.Entity;
using FluentValidation;
using joinfreela.Application.DTOs.Freelancer;
using joinfreela.Application.Validators.Base;
using joinfreela.Domain.Interfaces.Repositories;

namespace joinfreela.Application.Validators
{
    public class FreelancerRequestValidator: BaseUserRequestValidator<FreelancerRequest>
    {
        public FreelancerRequestValidator(ISkillRepository _skillRepository)
        {
            RuleForEach(fr=>fr.Skills)
                .Must(usr => _skillRepository.Query().Any(sk=>sk.Id==usr.SkillId))
                .WithMessage("A Skill informada não existe");
        }
    }
}