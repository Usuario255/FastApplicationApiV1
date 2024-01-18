using FastApplication.Application.Repositories;
using FastApplication.Application.Services;
using FastApplication.Domain.Repositories;
using FastApplication.Infrastructure.Context;
using FastApplication.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FastApplication.IoC
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataDbContext>();

            // Repositórios
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IWorkshopRepository, WorkshopRepository>();
            services.AddScoped<IAtaRepository, AtaRepository>();           

            // Services
            services.AddScoped<IColaboradorService, ColaboradorService>();
            services.AddScoped<IWorkshopService, WorkshopService>();
            services.AddScoped<IAtaService, AtaService>();

            // HttpContextAccessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // SwaggerGenOptions
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
