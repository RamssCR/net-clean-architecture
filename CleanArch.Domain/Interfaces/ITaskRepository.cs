namespace CleanArch.Domain.Interfaces;
using Entities;

public interface ITaskRepository
{
    Task AddTask(TaskItem task);
    Task<IEnumerable<TaskItem>> GetPendingTasks();
    Task<IEnumerable<TaskItem>> GetCompletedTasks();
    Task<TaskItem?> GetTaskById(Guid id);
}