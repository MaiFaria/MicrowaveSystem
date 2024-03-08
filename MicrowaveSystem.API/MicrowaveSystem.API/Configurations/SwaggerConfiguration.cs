using Microsoft.OpenApi.Models;

namespace MicrowaveSystem.API.Configurations;

public static class SwaggerConfiguration
{
    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Digital Microwave API",
                Description = "A system to simulate microwave commands =D ",
            });
        });
    }

    public static void UseSwaggerDocumentation(this IApplicationBuilder app,
                                               IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = string.Empty;
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}

