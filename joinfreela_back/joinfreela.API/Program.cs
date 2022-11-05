using joinfreela.API.Configuration;
using joinfreela.API.Filters;
using joinfreela.Application.Mappers;
using joinfreela.Application.Options;
using joinfreela.Infrastructure.Consumers;

//Builder
var builder = WebApplication.CreateBuilder(args);
ConfigureConfiguration(builder.Services, builder.Configuration);
ConfigureServices(builder.Services, builder.Configuration);

//App
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


ConfigureMiddleware(app, app.Services);
ConfigureEndpoints(app, app.Services);

app.Run();

void ConfigureConfiguration(IServiceCollection services,ConfigurationManager configuration)
{
    services.Configure<JWTOptions>(configuration.GetSection("JWTOptions"));
};

void ConfigureServices(IServiceCollection services, ConfigurationManager configuration){
    services.AddHttpContextAccessor();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddControllers(c=>
    {
        c.Filters.Add<ExceptionFilter>();
    });
    
    
    services.AddHostedService<PaymentDoneConsumer>();
    
    services.AddAuthConfiguration(configuration);
    services.AddDependencyInjection();
}

void ConfigureMiddleware(IApplicationBuilder app, IServiceProvider services)
{
    
    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
    
    app.UseAuthentication();
    app.UseAuthorization();

}
void ConfigureEndpoints(IEndpointRouteBuilder app, IServiceProvider services)
{
    app.MapControllers();
}