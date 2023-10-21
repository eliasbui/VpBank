namespace Common.Settings;

/// <summary>
///     DbSettings
/// </summary>
public class DbSettings
{
    /// <summary>
    ///     Server
    /// </summary>
    public string Server { get; set; } = default!;

    /// <summary>
    /// </summary>
    public string Port { get; set; } = default!;

    /// <summary>
    ///     Database
    /// </summary>
    public string Database { get; set; } = default!;

    /// <summary>
    ///     UserId
    /// </summary>
    public string UserId { get; set; } = default!;

    /// <summary>
    ///     Password
    /// </summary>
    public string Password { get; set; } = default!;
}