namespace CleanArch.Application.UseCases.Task.CreateTask;
using Dtos.Task.CreateTask;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;

public class CreateTaskHandler(ITaskRepository repository)
{
    /// <summary>
    /// Creates a new task using a request DTO as well as
    /// returning a response DTO with the created task.
    /// </summary>
    /// <param name="request">The request DTO.</param>
    /// <returns>The response DTO with the new task data.</returns>
    public async Task<CreateTaskResponse> HandleAsync(CreateTaskRequest request)
    {
        var title = new TaskTitle(request.Title);
        var task = new TaskItem(title, request.Description);
        
        await repository.AddTask(task);
        await repository.SaveChangesAsync();

        return new CreateTaskResponse(
            task.Id,
            task.Title.ToString(),
            task.Description,
            task.IsCompleted
        );
    }
}