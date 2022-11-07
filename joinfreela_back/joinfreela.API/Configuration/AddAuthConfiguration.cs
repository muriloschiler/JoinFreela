using System.Text;
using joinfreela.Application.Constants;
using joinfreela.Application.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace joinfreela.API.Configuration
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAuthConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            var settings = configuration.GetSection("JWTOptions").Get<JWTOptions>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.SecretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
            });

            // authorization
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(UserRoles.Owner, policy => policy.RequireRole(UserRoles.Owner));
                opt.AddPolicy(UserRoles.Freelancer, policy => policy.RequireRole(UserRoles.Freelancer));
                opt.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
            });

            return services;
        } 
    }
}