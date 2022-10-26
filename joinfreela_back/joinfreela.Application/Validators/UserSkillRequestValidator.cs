using System.Data.Entity;
using FluentValidation;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Domain.Interfaces.Repositories;

namespace joinfreela.Application.Validators
{
    public class UserSkillRequestValidator: AbstractValidator<UserSkillRequest>
    {
        public UserSkillRequestValidator(ISkillRepository _skillRepository)
        {
            RuleFor(usr=>usr.SkillId)
                .MustAsync(async (skillId,CancellationToken)=>
                    await _skillRepository.Query().AnyAsync(sk=>sk.Id==skillId))
                .WithMessage("A Skill informada não existe");
        }
    }
}