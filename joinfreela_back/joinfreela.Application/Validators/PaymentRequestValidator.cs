using System.Data.Entity;
using FluentValidation;
using joinfreela.Application.DTOs.Payment;
using joinfreela.Domain.Interfaces.Repositories;

namespace joinfreela.Application.Validators
{
    public class PaymentRequestValidator: AbstractValidator<PaymentRequest>
    {
        public PaymentRequestValidator(IContractRepository _contractRepository)
        {
            RuleFor(pr=>pr.ContractId)
                .MustAsync(async (contractId,CancellationToken) =>
                    await _contractRepository.Query().AnyAsync(co => co.Id==contractId))
                .WithMessage("Contrato não existe");

            RuleFor(pr=>pr.ContractId)
                .MustAsync(async (contractId,CancellationToken) =>
                    await _contractRepository.Query().AnyAsync(co => co.Id==contractId && co.Active==0))
                .WithMessage("Contrato não está ativo");
        }
    }
}