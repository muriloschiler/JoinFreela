using joinfreela.Application.Mappers;
using joinfreela.Infrastructure.Data;

namespace joinfreela.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services){
            services.AddDbContext<JoinFreelaDbContext>();
            services.AddAutoMapper(typeof(RequestToDomainProfile),typeof(DomainToResponseProfile));

            return services;     
        }
    }
}