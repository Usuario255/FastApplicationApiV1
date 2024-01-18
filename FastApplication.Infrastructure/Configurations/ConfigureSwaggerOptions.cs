using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IServiceProvider serviceProvider;

    public ConfigureSwaggerOptions(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public void Configure(SwaggerGenOptions options)
    {       
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Minha API",
            Version = "v1",
            Description = "Desafio Fast",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "Fast API",
                Email = "fast@email.com",
                Url = new Uri("https://fast.com"),
            },
            License = new Microsoft.OpenApi.Models.OpenApiLicense
            {
                Name = "Licença",
                Url = new Uri("https://opensource.org/licenses/MIT"),
            }
        });
   
        options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT"
        });
       
        options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference
                    {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
      
        options.IncludeXmlComments(GetXmlCommentsPath());
    }

    private string GetXmlCommentsPath()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var xmlFile = $"{assembly.GetName().Name}.xml";
        return Path.Combine(AppContext.BaseDirectory, xmlFile);
    }
}
