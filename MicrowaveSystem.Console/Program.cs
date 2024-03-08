using Microsoft.Extensions.DependencyInjection;
using MicrowaveSystem.Console.Configurations;
using MicrowaveSystem.Console.Mappings;
using MicrowaveSystem.Core.UseCases.Contracts;

var services = new ServiceCollection();
services.MapModules();

MicrowaveInjection.RegisterServices(services);

var service = services.BuildServiceProvider()
                      .GetRequiredService<IMenuService>();

service.Start();