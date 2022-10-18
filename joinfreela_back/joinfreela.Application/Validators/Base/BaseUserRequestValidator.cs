using FluentValidation;
using joinfreela.Application.DTOs.Common;

namespace joinfreela.Application.Validators.Base
{
    public class BaseUserRequestValidator<T>: AbstractValidator<T>
    where T:UserViewModel
    {
        public BaseUserRequestValidator()
        {
            RuleFor(uv=>uv.Name)
                .NotEmpty()
                .MaximumLength(30);
            
            RuleFor(uv=>uv.Username)
                .NotEmpty()
                .MaximumLength(30);
            
            RuleFor(uvm=>uvm.Email)
                .NotEmpty()
                .EmailAddress();

        }
    }
}