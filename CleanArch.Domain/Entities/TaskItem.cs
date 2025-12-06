namespace CleanArch.Domain.Entities;
using ValueObjects;

public class TaskItem : BaseEntity
{
    public TaskTitle Title { get; set; }
    public bool Done { get; set; } = false;
}