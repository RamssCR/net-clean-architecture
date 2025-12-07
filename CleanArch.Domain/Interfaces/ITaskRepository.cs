namespace CleanArch.Domain.Interfaces;
using Entities;

public interface ITaskRepository
{
    Task AddTask(TaskItem task);
    Task<IReadOnlyList<TaskItem>> GetPendingTasks();
    Task<TaskItem?> GetTaskById(Guid id);
    Task SaveChangesAsync();
}