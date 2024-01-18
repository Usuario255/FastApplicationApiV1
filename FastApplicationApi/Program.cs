using FastApplication.Infrastructure.Configurations;
using FastApplication.Infrastructure.Context;
using FastApplication.IoC;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.ResolveDependencies();

builder.Services.AddDbContext<DataDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddApiConfig();

builder.Services.AddSwaggerConfig();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MinhaPolitica", app =>
    {
        app.AllowAnyOrigin();
        app.AllowAnyMethod();
        app.AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("MinhaPolitica");

app.UseAuthorization();

app.UseApiConfig(app.Environment);

app.UseSwaggerConfig();

app.Run();
