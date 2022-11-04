using System.Collections.Generic;
using Serilog.Core;
using Serilog.Events;

namespace Samhammer.Logging.Serilog
{
    public class BlackListEnricher : ILogEventEnricher
    {
        private HashSet<string> secrets;

        public BlackListEnricher(HashSet<string> secrets)
        {
            this.secrets = secrets;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var propsToModify = new List<LogEventProperty>();
            foreach (var property in logEvent.Properties)
            {
                var value = property.Value.ToString();

                foreach (var secret in secrets)
                {
                    value = value.Replace(secret, new string('*', secret.Length));
                }

                if (value != property.Value.ToString())
                {
                    propsToModify.Add(propertyFactory.CreateProperty(property.Key, value));
                }
            }

            propsToModify.ForEach(logEvent.AddOrUpdateProperty);
        }
    }
}