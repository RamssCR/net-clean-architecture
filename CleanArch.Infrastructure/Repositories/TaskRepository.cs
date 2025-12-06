using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    public Task AddTask(TaskItem task)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TaskItem>> GetPendingTasks()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TaskItem>> GetCompletedTasks()
    {
        throw new NotImplementedException();
    }

    public Task<TaskItem?> GetTaskById(Guid id)
    {
        throw new NotImplementedException();
    }
}