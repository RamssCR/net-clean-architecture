namespace CleanArch.Application.Dtos.Task.CreateTask;
using Domain.ValueObjects;

public record CreateTaskResponse(Guid Id, TaskTitle Title, bool Done);