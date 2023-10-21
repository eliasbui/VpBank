using Common.Options;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace API.Register;

public static class SerilogService
{
    public static void GetInitialize(IConfigurationRoot configuration)
    {
        var logModelOption = configuration.GetSection(LogOption.Position).Get<LogOption>();

        if (logModelOption?.File?.Path == null || logModelOption.Kafka == null)
        {
            throw new UnauthorizedAccessException();
        }

        var levelSwitch = new LoggingLevelSwitch();


        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.ControlledBy(levelSwitch)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File(
                logModelOption.File.Path,
                rollingInterval: RollingInterval.Day)
            .CreateLogger();

        if (logModelOption.LogLevel?.SwitchLevelLog != null &&
            Enum.TryParse<LogEventLevel>(logModelOption.LogLevel.SwitchLevelLog, out var level))
        {
            levelSwitch.MinimumLevel = level;
        }

        LoggerFactory
            .Create(builder => builder.AddSerilog(dispose: true));
    }
}
