using FluentValidation;
using joinfreela.Application.DTOs.Job;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Models.Base;
using joinfreela.Domain.Models.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace joinfreela.Application.Validators
{
    public class JobRequestValidator:AbstractValidator<JobRequest>
    {
        public JobRequestValidator(IProjectRepository _projectRepository )
        {
            RuleFor(jr=>jr.Title)
                .NotEmpty()
                .MaximumLength(30);
            
            RuleFor(jr=>jr.Description)
                .NotEmpty()
                .MaximumLength(1000);
            
            RuleFor(jr=>jr.Salary)
                .NotEmpty();

            RuleFor(jr=>jr.SeniorityId)
                .Must(se=> Enumeration.GetAll<Seniority>().Any(se=>se.Id == se.Id))
                .WithMessage("O tipo de senioridade está inválido");
            
        }   
    }
}