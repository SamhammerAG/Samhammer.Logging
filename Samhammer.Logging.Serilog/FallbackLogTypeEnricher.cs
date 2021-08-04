using Serilog.Core;
using Serilog.Events;

namespace Samhammer.Logging.Serilog
{
    public class FallbackLogTypeEnricher: ILogEventEnricher
    {
        private readonly BaseLogType fallback;
        
        public FallbackLogTypeEnricher(BaseLogType fallback)
        {
            this.fallback = fallback;
        }
        
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("logType", fallback.ToString()));
        }
    }
}