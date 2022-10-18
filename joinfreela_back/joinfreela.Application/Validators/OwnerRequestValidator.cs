using FluentValidation;
using joinfreela.Application.DTOs.Owner;
using joinfreela.Application.Validators.Base;

namespace joinfreela.Application.Validators
{
    public class OwnerRequestValidator: BaseUserRequestValidator<OwnerRequest>
    {   
        public OwnerRequestValidator()
        {}
    }
}