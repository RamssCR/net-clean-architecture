using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Repositories;

public class TaskRepository(AppDbContext context) : ITaskRepository
{

    /// <summary>
    /// Adds a tasks to the Task Entity.
    /// </summary>
    /// <param name="task">The new task to add.</param>
    public async Task AddTask(TaskItem task) => await context.Tasks.AddAsync(task);

    /// <summary>
    /// Gets all pending tasks.
    /// </summary>
    /// <returns>The found pending tasks.</returns>
    public async Task<IReadOnlyList<TaskItem>> GetPendingTasks() =>
        await context.Tasks
            .Where(task => task.IsCompleted == false)
            .ToListAsync();

    /// <summary>
    /// Returns a task by its ID or null if not found.
    /// </summary>
    /// <param name="id">The ID to search with.</param>
    /// <returns>The found task or null if not found.</returns>
    public async Task<TaskItem?> GetTaskById(Guid id) =>
        await context.Tasks.FindAsync(id);
    
    /// <summary>
    /// Saves changes made to an entity.
    /// </summary>
    public async Task SaveChangesAsync() => await context.SaveChangesAsync();

}