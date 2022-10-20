using System.Reflection;
using FluentValidation.AspNetCore;
using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Services;
using joinfreela.Application.Utils;
using joinfreela.Application.Validators;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.UnitOfWork;
using joinfreela.Infrastructure.Data;
using joinfreela.Infrastructure.Repositories;
using joinfreela.Infrastructure.UnitOfWork;

namespace joinfreela.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services){
            services.AddDbContext<JoinFreelaDbContext>();
            services.AddScoped<IUnityOfWork,UnitOfWork>();
            services.AddScoped<IOwnerRepository,OwnerRepository>();
            services.AddScoped<IFreelancerRepository,FreelancerRepository>();
            services.AddScoped<IProjectRepository,ProjectRepository>();
            services.AddScoped<SkillRepository,SkillRepository>();
            services.AddScoped<IContractRepository,ContractRepository>();
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<ISkillService,SkillService>();
            services.AddScoped<IProjectService,ProjectService>();

            services.AddFluentValidation(fv =>
            {
                fv.AutomaticValidationEnabled = false;
                fv.RegisterValidatorsFromAssemblyContaining<OwnerRequestValidator>(
                    asr => !(asr.ValidatorType.GetCustomAttribute<IgnoreInjectionAttribute>()?.Ignore ?? false)
                );
            });

            return services;     
        }
    }
}