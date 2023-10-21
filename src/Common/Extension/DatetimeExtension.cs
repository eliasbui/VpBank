namespace Common.Extension;

/// <summary>
///     Extension for DateTime
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    ///     Convert DateTime to UnixTimeMilliseconds
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static string ToUnixTimeMilliseconds(this DateTime dateTime)
    {
        DateTimeOffset dto = new(dateTime.ToUniversalTime());
        return dto.ToUnixTimeMilliseconds().ToString();
    }
}