using MicrowaveSystem.Core.UseCases.Contracts;
using MicrowaveSystem.Core.UseCases.ServiceHandlers;

namespace MicrowaveSystem.API.IOC;

public class MicrowaveInjections : IInjection
{
    public void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IMicrowaveService, MicrowaveService>();
        services.AddScoped<IJobService, JobService>();
    }
}
