namespace Common.Base;

public class BaseResultApiResponse<T>
{
    public bool Success { get; set; }

    public string Message { get; set; } = default!;

    /// <summary>
    ///     Status code
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    ///     Result
    /// </summary>
    public IReadOnlyList<T>? Result { get; set; } = default!;

}