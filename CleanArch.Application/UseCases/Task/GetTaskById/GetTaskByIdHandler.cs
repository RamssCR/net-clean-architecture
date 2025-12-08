using CleanArch.Application.Common;
using CleanArch.Application.Dtos.Task.GetTaskById;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.UseCases.Task.GetTaskById;

public class GetTaskByIdHandler(ITaskRepository repository)
{
    /// <summary>
    /// Returns a task found by a passed ID or an error message
    /// if none was found.
    /// </summary>
    /// <param name="request">The ID passed as a request.</param>
    /// <returns>The found task (or an error message if not found).</returns>
    public async Task<Result<GetTaskByIdResponse>> HandleAsync(GetTaskByIdRequest request)
    {
        var task = await repository.GetTaskById(request.Id);
        if (task is null)
            return Result<GetTaskByIdResponse>.Failure("Task could not be found");

        var response = new GetTaskByIdResponse(
            task.Id,
            task.Title.ToString(),
            task.Description,
            task.IsCompleted
        );
        
        return Result<GetTaskByIdResponse>.Ok(response);
    }
}