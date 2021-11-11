using System;
using Serilog;
using Serilog.Configuration;
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

        public static LoggerConfiguration WithFallbackLogType(this LoggerEnrichmentConfiguration configuration,
            BaseLogType fallback)
        {
            return configuration.With(new FallbackLogTypeEnricher(fallback));
        }

        /// <summary>
        /// Attempts to Replaces bearer Tokens and refresh tokens from LogDetails using regex with "maskedData.
        /// </summary>
        public static LoggerConfiguration WithTokenMasker(this LoggerEnrichmentConfiguration configuration)
        {
            return configuration.With(new TokenMaskLogEventEnricher());
        }
    }
}
