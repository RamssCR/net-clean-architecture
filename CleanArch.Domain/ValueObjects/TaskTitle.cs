namespace CleanArch.Domain.ValueObjects;

public sealed record TaskTitle
{
    public string Title { get; init; } = string.Empty;
    
    private TaskTitle() { }
    
    public TaskTitle(string title)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentOutOfRangeException.ThrowIfLessThan(title.Length, 4);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(title.Length, 50);
        Title = title.Trim();
    }
}