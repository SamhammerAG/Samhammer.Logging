using System;
using Serilog.Events;

namespace Samhammer.Logging.Serilog
{
    public static class SerilogExtensions
    {
        public static LogEventLevel ToSerilogLogLevel(this LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Verbose => LogEventLevel.Verbose,
                LogLevel.Debug => LogEventLevel.Debug,
                LogLevel.Information => LogEventLevel.Information,
                LogLevel.Warning => LogEventLevel.Warning,
                LogLevel.Error => LogEventLevel.Error,
                LogLevel.Fatal => LogEventLevel.Fatal,
                _ => throw new Exception("unknown logLevel")
            };
        }
    }
}
