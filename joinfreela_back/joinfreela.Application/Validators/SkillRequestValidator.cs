using FluentValidation;
using joinfreela.Application.DTOs.Skill;
using joinfreela.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace joinfreela.Application.Validators
{
    public class SkillRequestValidator: AbstractValidator<SkillRequest>
    {
        public SkillRequestValidator(ISkillRepository _skillRepository)
        {
            RuleFor(sr=>sr.Name)
                .NotEmpty()
                .MaximumLength(30)
                .WithMessage("Nome de Skill inválida");                
        }
    }
}