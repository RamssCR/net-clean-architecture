namespace CleanArch.Infrastructure.DependencyInjection;
using Persistence;
using Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    /// <summary>
    /// Creates an extension method to the service builder that adds the
    /// infrastructure configuration and initialization through injection.
    /// Additionally, it handles all repositories in this application.
    /// </summary>
    /// <param name="services">The service builder provider.</param>
    /// <param name="configuration">The configuration services that loads the appsettings.json.</param>
    /// <returns>The method that adds the database configuration through injection.</returns>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        var basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));
        var connection = Path.Combine(basePath, connectionString);
        
        services
            .AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={connection}"));

        services.AddScoped<ITaskRepository, TaskRepository>();
        return services;
    }
}