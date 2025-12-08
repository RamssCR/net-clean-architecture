namespace CleanArch.Application.Dtos.Task.GetTaskById;

public record GetTaskByIdResponse(
    Guid Id,
    string Title,
    string? Description,
    bool IsCompleted
);