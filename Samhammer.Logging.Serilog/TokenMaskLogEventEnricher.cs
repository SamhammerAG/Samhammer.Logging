using System.Collections.Generic;
using System.Text.RegularExpressions;
using Serilog.Core;
using Serilog.Events;

namespace Samhammer.Logging.Serilog
{
    public class TokenMaskLogEventEnricher : ILogEventEnricher
    {
        // language=regex matches url encoded (refresh_token=eyJhbGciOiJIUzI1N) and json ("refresh_token":"eyJhbGciOiJIUzI1N")
        private const string UrlRefreshTokenPattern = "(?<=refresh_token=|refresh_token\":\")[^\" \n&]*";
        // language=regex
        private const string BearerTokenPattern = "Bearer [^\" ]*";
        // ReSharper disable once InconsistentNaming
        private readonly Regex bearerTokenRegex = new Regex($"({BearerTokenPattern}|{UrlRefreshTokenPattern})", RegexOptions.Compiled & RegexOptions.IgnoreCase);
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var propsToModify = new List<LogEventProperty>();
            foreach (var p in logEvent.Properties)
            {
                var changed = false;
                // use matchSelector to set flag if there were matches, that way only properties that need to be changed will be updated
                var match = bearerTokenRegex.Replace(p.Value.ToString(), x =>
                {
                    changed = true;
                    return "maskedToken";
                });

                if (changed)
                {
                    propsToModify.Add(propertyFactory.CreateProperty(p.Key, match));
                }
            }

            propsToModify.ForEach(logEvent.AddOrUpdateProperty);
        }
    }

}
