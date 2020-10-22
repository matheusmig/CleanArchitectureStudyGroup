using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Modules.Common.Swagger
{
    public static class SwaggerExtensions
    {

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
                .AddSwaggerGen(
                    c =>
                    {
                        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                        {
                            In = ParameterLocation.Header,
                            Description = "Please insert JWT with Bearer into field",
                            Name = "Authorization",
                            Type = SecuritySchemeType.ApiKey
                        });
                        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme
                            {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                            },
                            new string[] { }
                        }
                        });
                    });

            return services;
        }

        public static IApplicationBuilder UseVersionedSwagger(
            this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider,
            IConfiguration configuration,
            IWebHostEnvironment env)
        {
            // This will redirect default url to Swagger url
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
                    {
                        string swaggerEndpoint;

                        string basePath = configuration["ASPNETCORE_BASEPATH"];

                        if (!string.IsNullOrEmpty(basePath))
                        {
                            swaggerEndpoint = $"{basePath}/swagger/{description.GroupName}/swagger.json";
                        }
                        else
                        {
                            swaggerEndpoint = $"/swagger/{description.GroupName}/swagger.json";
                        }

                        options.SwaggerEndpoint(swaggerEndpoint, description.GroupName.ToUpperInvariant());
                    }
                });

            return app;
        }
    }
}
