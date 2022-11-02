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
                .MustAsync(async (skillId,CancellationToken)=>
                    await _skillRepository.Query().AnyAsync(sk=>sk.Id==skillId))
                .WithMessage("A Skill informada não existe");
        }
    }
}