using CleanArch.Presentation.Menus;
using Microsoft.Extensions.Hosting;
using CleanArch.Application.DependencyInjection;
using CleanArch.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration
    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"))
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
await TaskMenu.RunAsync(app.Services);