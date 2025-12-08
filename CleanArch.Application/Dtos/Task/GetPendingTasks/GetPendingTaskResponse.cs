namespace CleanArch.Application.Dtos.Task.GetPendingTasks;

public sealed record GetPendingTaskResponse(
    Guid Id,
    string Title,
    string? Description,
    bool IsCompleted
);