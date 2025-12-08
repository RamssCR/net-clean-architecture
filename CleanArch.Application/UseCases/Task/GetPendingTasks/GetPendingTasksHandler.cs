using CleanArch.Application.Dtos.Task.GetPendingTasks;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.UseCases.Task.GetPendingTasks;

public class GetPendingTasksHandler(ITaskRepository repository)
{
    /// <summary>
    /// Returns a list of pending tasks.
    /// </summary>
    /// <returns>The list of found pending tasks.</returns>
    public async Task<IReadOnlyList<GetPendingTaskResponse>> HandleAsync()
    {
        var tasks = await repository.GetPendingTasks();
        return tasks
            .Select(task => new GetPendingTaskResponse(
                task.Id,
                task.Title.ToString(),
                task.Description,
                task.IsCompleted
            ))
            .ToList();
    }
}