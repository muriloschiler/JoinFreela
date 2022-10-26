using FluentValidation;
using joinfreela.Application.DTOs.Nomination;
using joinfreela.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace joinfreela.Application.Validators
{
    public class NominationRequestValidator:AbstractValidator<NominationRequest>
    {
        public NominationRequestValidator(IProjectRepository _projectRepository)
        {
            RuleFor(nr=>nr.JobId)
                .NotEmpty()
                .MustAsync(async(jobId,CancellationToken)=>
                    await _projectRepository.Query()
                        .Include(pr=>pr.Jobs)
                        .AnyAsync(pr=> pr.Jobs.Any(jo=>jo.Id==jobId)))
                .WithMessage("Vaga não encontrada");

        
            RuleFor(nr=>nr.JobId)
                .NotEmpty()
                .MustAsync(async(jobId,CancellationToken)=>
                    await _projectRepository.Query()
                        .Include(pr=>pr.Jobs)
                        .AnyAsync(pr=> pr.Jobs.Any(jo=>jo.Id==jobId && jo.Open==0)))
                .WithMessage("Vaga não se encontra mais ativa");

            RuleFor(nr=>nr.JobId)
                .NotEmpty()
                .MustAsync(async(jobId,CancellationToken)=>
                    await _projectRepository.Query()
                        .Include(pr=>pr.Jobs)
                        .AnyAsync(pr=> pr.Jobs.Any(jo=>jo.Id==jobId) && pr.Active == 0))
                .WithMessage("O projeto não se encontra mais ativo ");            
        }
    }
}