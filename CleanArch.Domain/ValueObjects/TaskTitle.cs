namespace CleanArch.Domain.ValueObjects;

public readonly record struct TaskTitle()
{
    private string Title { get; }
    
    private TaskTitle(string title) : this()
    {
        ArgumentException.ThrowIfNullOrEmpty(Title);
        ArgumentOutOfRangeException.ThrowIfLessThan(Title.Length, 4);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(Title.Length, 50);
        Title = title;
    }
    
    /// <summary>Changes the title value.</summary>
    /// <param name="title">The value passed by the user.</param>
    /// <returns>A new record object with the new title value.</returns>
    public static TaskTitle ChangeTitle(string title) => new(title);
}