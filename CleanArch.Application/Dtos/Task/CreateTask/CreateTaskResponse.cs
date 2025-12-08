namespace CleanArch.Application.Dtos.Task.CreateTask;

public record CreateTaskResponse(
    Guid Id,
    string Title,
    string? Description,
    bool IsCompleted
);