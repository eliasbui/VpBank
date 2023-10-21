using System.Net;
using Common.Model;
using Newtonsoft.Json;
using Serilog.Events;

namespace Common.Extension;

public static class LoggerExtension
{
    /// <summary>
    ///     Generate log
    /// </summary>
    /// <param name="messageLog"></param>
    /// <param name="serviceName"></param>
    /// <param name="logEventLevel"></param>
    /// <returns></returns>
    public static string GeneratedLog(this string messageLog, string serviceName, LogEventLevel logEventLevel)
    {
        var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        var ipAddress = ipHostInfo.AddressList[0];
        var logModel = new LogModel
        {
            FullData = messageLog,
            Timestamp = DateTime.UtcNow.ToUnixTimeMilliseconds(),
            SourceIp = ipAddress.ToString(),
            ServiceName = serviceName,
            Level = logEventLevel.ToString(),
            CustomTimestamp = DateTime.UtcNow.AddHours(7).ToUnixTimeMilliseconds()
        };

        return JsonConvert.SerializeObject(logModel);
    }

}