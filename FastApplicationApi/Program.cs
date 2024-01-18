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


var app = builder.Build();

app.UseApiConfig(app.Environment);

app.UseSwaggerConfig();

app.Run();
