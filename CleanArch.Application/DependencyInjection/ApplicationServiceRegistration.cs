namespace CleanArch.Application.DependencyInjection;
using UseCases.Task.CreateTask;
using UseCases.Task.GetTaskById;
using UseCases.Task.GetPendingTasks;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationServiceRegistration
{
    /// <summary>
    /// Extends the service builder method to add
    /// transient handlers from the application layer.
    /// </summary>
    /// <param name="services">The service builder.</param>
    /// <returns>The service with the new extended method.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<GetPendingTasksHandler>();
        services.AddTransient<GetTaskByIdHandler>();
        services.AddTransient<CreateTaskHandler>();
        return services;
    }
}