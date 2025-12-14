namespace CleanArch.Presentation.Menus;
using Application.Dtos.Task.CreateTask;
using Application.Dtos.Task.GetTaskById;
using Application.UseCases.Task.CreateTask;
using Application.UseCases.Task.GetPendingTasks;
using Application.UseCases.Task.GetTaskById;
using Microsoft.Extensions.DependencyInjection;

public static class TaskMenu
{
    /// <summary>
    /// Runs the main menu application on console.
    /// </summary>
    /// <param name="service">The service that fetches the task application methods.</param>
    public static async Task RunAsync(IServiceProvider service)
    {
        Console.Clear();
        Console.WriteLine("------------- TASK APP --------------");
        Console.WriteLine("1. Create a task");
        Console.WriteLine("2. Get all pending tasks");
        Console.WriteLine("3. Get a task by id");
        
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                await CreateTask(service);
                break;
            case "2":
                await GetPendingTasks(service);
                break;
            case "3":
                await GetTaskById(service);
                break;
            default:
                Console.WriteLine("Please enter a valid input");
                break;
        }
    }
    
    /// <summary>
    /// Creates a tasks and shows it on console.
    /// </summary>
    /// <param name="service">The service that fetches the task application methods.</param>
    private static async Task CreateTask(IServiceProvider service)
    {
        Console.WriteLine("Please enter a name for the task");
        var name = Console.ReadLine() ?? string.Empty;
        
        Console.WriteLine("Please enter a description for the task");
        var description = Console.ReadLine() ?? null;

        // Since this is a console app, we have to manually activate scoped operations.
        using var scoped = service.CreateScope();
        
        var handler = scoped.ServiceProvider.GetRequiredService<CreateTaskHandler>();
        var task = await handler.HandleAsync(new CreateTaskRequest(name, description));

        Console.WriteLine($"Task {task.Id} created");
    }

    /// <summary>
    /// Gets all pending tasks and displays them on the console.
    /// </summary>
    /// <param name="service">The service that fetches the task application methods.</param>
    private static async Task GetPendingTasks(IServiceProvider service)
    {
        using var scoped = service.CreateScope();
        
        var handler = scoped.ServiceProvider.GetRequiredService<GetPendingTasksHandler>();
        var tasks = await handler.HandleAsync();

        foreach (var task in tasks)
        {
            Console.WriteLine($"Task {task.Id}:");
            Console.WriteLine($"    Title: {task.Title}");
            Console.WriteLine($"    Description: {task.Description ?? "No description provided"}{Environment.NewLine}");
        }
    }

    /// <summary>
    /// Gets a task by its ID and displays is on the console.
    /// </summary>
    /// <param name="service">The service that fetches the task application methods.</param>
    private static async Task GetTaskById(IServiceProvider service)
    {
        Console.WriteLine("Please enter a task id");
        var id = Console.ReadLine() ?? string.Empty;

        if (!Guid.TryParse(id, out var taskId))
            Console.WriteLine("Please enter a valid task id");
        
        using var scoped = service.CreateScope();
        
        var handler = scoped.ServiceProvider.GetRequiredService<GetTaskByIdHandler>();
        var task = await handler.HandleAsync(new GetTaskByIdRequest(taskId));
        
        Console.WriteLine($"Task {task.Data?.Id}:");
        Console.WriteLine($"    Title: {task.Data?.Title}");
        Console.WriteLine($"    Description: {task.Data?.Description}");
    }
}