using Microsoft.OpenApi.Models;
namespace WebApi.Configrations;

public static class SwaggerConfigration
{
    public static void RegisterSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Silikon Web Api", Version = "v1" });
            c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Query,
                Type = SecuritySchemeType.ApiKey,
                Name = "key",
                Description = "Enter API-Key",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ApiKey"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }
}
