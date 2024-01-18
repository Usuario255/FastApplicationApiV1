using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace FastApplication.Infrastructure.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
               
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");              
            });

            return app;
        }

        private static OpenApiInfo CreateInfoForApiVersion(string version)
        {
            return new OpenApiInfo
            {
                Title = "API - Fast",
                Version = version,
                Description = "Esta API foi criada para fins de realização de desafio da empresa FAST.",
                Contact = new OpenApiContact { Name = "Fast", Email = "contato@fast.com" },
                License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            };
        }
    }
}
