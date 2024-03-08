using Microsoft.Extensions.DependencyInjection;
using Microwave.Infra.Repositories;
using MicrowaveSystem.Core.Interfaces;
using MicrowaveSystem.Core.UseCases.Contracts;
using MicrowaveSystem.Core.UseCases.ServiceHandlers;

namespace MicrowaveSystem.Console.Configurations;

public class MicrowaveInjection
{ 
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IMenuService, MenuService>();
        services.AddSingleton<IMicrowaveService, MicrowaveService>();
        services.AddSingleton<IJobService, JobService>();
        services.AddSingleton<ITemplatesRepository, TemplatesRepository>();
    }
}

