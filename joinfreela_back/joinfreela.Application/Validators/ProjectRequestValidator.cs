using FluentValidation;
using joinfreela.Application.DTOs.Project;

namespace joinfreela.Application.Validators
{
    public class ProjectRequestValidator : AbstractValidator<ProjectRequest>
    {
        public ProjectRequestValidator()
        {
            RuleFor(pr=>pr.Name)
                .NotEmpty()
                .MaximumLength(30);
            RuleFor(pr=>pr.Description)
                .NotEmpty()
                .MaximumLength(500);    
        }
    }
}