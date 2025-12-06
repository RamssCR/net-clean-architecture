using CleanArch.Domain.Exceptions;

namespace CleanArch.Domain.Entities;
using ValueObjects;

public class TaskItem : BaseEntity
{
    public TaskTitle Title { get; private set; }
    public string? Description { get; private set; }
    public bool IsCompleted { get; private set; }

    public TaskItem(TaskTitle title, string? description = null)
    {
        Title = title;
        Description = description;
    }

    /// <summary>
    /// Toggles the state of a task.
    /// </summary>
    public void ToggleCompletedState() => IsCompleted = !IsCompleted;

    /// <summary>
    /// Updates the task title.
    /// </summary>
    /// <param name="title">The new task title.</param>
    public void UpdateTitle(TaskTitle title)
    {
        if (Title == title) return;
        if (IsCompleted) throw new ValidationException("Cannot modify an already completed task");
        Title = title;
    }

    /// <summary>
    /// Updates the task description.
    /// </summary>
    /// <param name="description">The new task description.</param>
    /// <exception cref="ValidationException">
    /// If the new description surpasses 500 characters.
    /// </exception>
    public void UpdateDescription(string? description)
    {
        if (Description == description) return;
        if (IsCompleted) throw new ValidationException("Cannot modify an already completed task");
        if (description is { Length: > 500 })
            throw new ValidationException("Description cannot contain more than 500 characters");
        
        Description = description;
    }
}