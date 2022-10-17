using joinfreela.Application.Interfaces.Services;
using joinfreela.Application.Mappers;
using joinfreela.Application.Services;
using joinfreela.Domain.Interfaces.Repositories;
using joinfreela.Domain.Interfaces.Repositories.Base;
using joinfreela.Domain.Models;
using joinfreela.Infrastructure.Data;
using joinfreela.Infrastructure.Repositories;

namespace joinfreela.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services){
            services.AddDbContext<JoinFreelaDbContext>();
            services.AddAutoMapper(typeof(RequestToDomainProfile),typeof(DomainToResponseProfile));
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<IOwnerRepository,OwnerRepository>();
            services.AddScoped<IFreelancerRepository,FreelancerRepository>();
            services.AddScoped<IProjectRepository,ProjectRepository>();
            services.AddScoped<SkillRepository,SkillRepository>();
            services.AddScoped<IContractRepository,ContractRepository>();

            return services;     
        }
    }
}