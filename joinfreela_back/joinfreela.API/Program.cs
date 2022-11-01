using joinfreela.API.Configuration;
using joinfreela.API.Filters;
using joinfreela.Application.Mappers;
using joinfreela.Application.Options;
using joinfreela.Infrastructure.Consumers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(c=>
{
    c.Filters.Add<ExceptionFilters>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigureConfiguration(builder.Services,builder.Configuration);
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

void ConfigureConfiguration(IServiceCollection services,ConfigurationManager configuration)
{
    services.Configure<JWTOptions>(configuration.GetSection("JWTOptions"));
    services.Configure<URLPaymentsAPI>(configuration.GetSection("URLPaymentsAPI"));
};

void ConfigureServices(IServiceCollection services, ConfigurationManager configuration){
    services.AddDependencyInjection();
    services.AddAuthConfiguration(configuration);
    
    services.AddHttpContextAccessor();
    
    services.AddHostedService<PaymentDoneConsumer>();
}
