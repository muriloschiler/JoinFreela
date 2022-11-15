using FluentValidation;
using joinfreela.Application.DTOs.Owner;
using joinfreela.Application.Validators.Base;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.Repositories.Base;
using joinfreela.Domain.Models;

namespace joinfreela.Application.Validators
{
    public class OwnerRequestValidator : BaseUserRequestValidator<OwnerRequest, Owner>
    {
        public OwnerRequestValidator(IOwnerRepository _ownerRepository) : base(_ownerRepository)
        {}
    }
}