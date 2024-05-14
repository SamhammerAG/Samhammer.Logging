using Serilog.Core;
using Serilog.Events;

namespace Samhammer.Logging.Serilog.Enrichers;

public class FallbackLogTypeEnricher: ILogEventEnricher
{
    private readonly BaseLogType _fallback;
        
    public FallbackLogTypeEnricher(BaseLogType fallback)
    {
        _fallback = fallback;
    }
        
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("logType", _fallback.ToString()));
    }
}