using FluentValidation;
using joinfreela.Application.DTOs.Common.Base;
using joinfreela.Domain.Classes.Base;
using joinfreela.Domain.Interfaces.Repositories.Base;

namespace joinfreela.Application.Validators.Base
{
    public class BaseUserRequestValidator<T,E>: AbstractValidator<T>
    where T: UserRequest
    where E: User
    {
        public BaseUserRequestValidator(IBaseRepository<E> _repository)
        {
            RuleFor(uv=>uv.Name)
                .NotEmpty()
                .MaximumLength(30);
            
            RuleFor(uv=>uv.Username)
                .NotEmpty()
                .MaximumLength(30);
            
            RuleFor(uv=>uv.Email)
                .NotEmpty()
                .EmailAddress();
            
            RuleFor(uv=>uv.Email)
                .Must( email => 
                    {
                        return ! _repository.Query().Any(us => us.Email == email);
                    } 
                )
                .WithMessage("Email já cadastrado");

            RuleFor(uv=>uv.Username)
                .Must( username => 
                    {
                        return ! _repository.Query().Any(us => us.Username == username);
                    })
                .WithMessage("Username já cadastrado");
        }
    }
}