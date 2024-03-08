using Microsoft.Extensions.DependencyInjection;

namespace MicrowaveSystem.Console.Mappings
{
    public static class ModuleMapper
	{
        public static void MapModules(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies(),
                                   ServiceLifetime.Scoped);
        }
    }
}

