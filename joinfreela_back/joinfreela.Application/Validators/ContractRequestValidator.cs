using FluentValidation;
using joinfreela.Application.DTOs.Contract;
using joinfreela.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace joinfreela.Application.Validators
{
    public class ContractRequestValidator: AbstractValidator<ContractRequest>
    {
        public ContractRequestValidator
            (IFreelancerRepository _freelancerRepository,
            IProjectRepository _projectRepository)
        {
            RuleFor(cr=>cr.JobId)
            .NotEmpty()
            .MustAsync(async (jobId,CancellationToken)=>
                await _projectRepository.Query()
                    .Include(pr=>pr.Jobs)
                    .AnyAsync(pr=>pr.Jobs.Any(jo=>jo.Id == jobId)))
            .WithMessage("Vaga não encontrada");
            
            RuleFor(cr=>cr.JobId)
            .NotEmpty()
            .MustAsync(async (jobId,CancellationToken)=>
                await _projectRepository.Query()
                    .Include(pr=>pr.Jobs)
                    .AnyAsync(pr=>pr.Jobs.Any(jo=>jo.Open == 0)))
            .WithMessage("Vaga não se encontra mais ativa");

            RuleFor(cr=>cr.FreelancerId)
            .NotEmpty()
            .MustAsync(async (freelancerId,CancellationToken)=> 
                await _freelancerRepository.Query()
                    .AnyAsync(fr=>fr.Id == freelancerId))
            .WithMessage("Freelancer não encontrado");

            RuleFor(cr=>cr.FreelancerId)
            .NotEmpty()
            .MustAsync(async (freelancerId,CancellationToken)=> 
                await _freelancerRepository.Query()
                    .AnyAsync(fr=>fr.Active == 0))
            .WithMessage("Freelancer não se encontra mais ativo");
        }
    }
}