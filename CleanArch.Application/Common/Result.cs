namespace CleanArch.Application.Common;

public sealed record Result<T>(bool Success, T? Data, string? Error)
{
    /// <summary>
    /// Returns a success structured DTO for success responses.
    /// </summary>
    /// <param name="data">The data to send as response.</param>
    /// <returns>The structured DTO record.</returns>
    public static Result<T> Ok(T data)
        => new(true, data, null);
    
    /// <summary>
    /// Returns a failure structured DTO for failure responses.
    /// </summary>
    /// <param name="error">The error message to send as response.</param>
    /// <returns>The structured DTO record.</returns>
    public static Result<T> Failure(string error)
        => new(false, default, error);
}