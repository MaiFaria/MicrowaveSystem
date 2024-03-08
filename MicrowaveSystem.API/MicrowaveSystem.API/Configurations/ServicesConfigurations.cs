using Microsoft.EntityFrameworkCore;
using Microwave.Infra.Data;
using MicrowaveSystem.API.IOC;
using MicrowaveSystem.Core.Contexts;

namespace MicrowaveSystem.API.Configurations;

public static class ServicesConfigurations
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.RegisterServices();

        Configuration.Database.ConnectionString =
            builder.Configuration.GetConnectionString("DefaultConnection") ??
                                  string.Empty;

        Configuration.Secrets.ApiKey =
            builder.Configuration.GetSection("Secrets")
                                 .GetValue<string>("ApiKey") ??
                                 string.Empty;
    }

    public static void UseApiConfiguration(this IApplicationBuilder app,
                                           IWebHostEnvironment env)
    {
        app.UseSwaggerDocumentation(env);
        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseAuthorization();
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.GlobalServices();
        services.InternalServices();
        services.AddSwaggerDocumentation();
    }

    private static void InternalServices(this IServiceCollection services)
    {
        var modules = AppDomain.CurrentDomain.GetAssemblies()
                                             .SelectMany(row => row.GetTypes())
                                             .Where(row => typeof(IInjection)
                                                .IsAssignableFrom(row) &&
                                                row.Name != "IInjection")
                                             .Select(row => row).ToList();

        foreach (var item in modules)
        {
            var iinjection = Activator.CreateInstance(item) as IInjection;
            iinjection.RegisterServices(services);
        }
    }

    private static void AddDataBase(this WebApplication app)
    {
        var serviceScope = app.Services.CreateScope();
        var dataContext = serviceScope.ServiceProvider.GetService<PersistContext>();
        dataContext?.Database.EnsureCreated();
    }
}