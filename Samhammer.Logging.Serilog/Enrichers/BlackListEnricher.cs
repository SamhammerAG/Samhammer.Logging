using System.Collections.Generic;
using Serilog.Core;
using Serilog.Events;

namespace Samhammer.Logging.Serilog.Enrichers
{
    public class BlackListEnricher : ILogEventEnricher
    {
        private string[] blackList;

        public BlackListEnricher(string[] blackList)
        {
            this.blackList = blackList;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var propsToModify = new List<LogEventProperty>();
            foreach (var property in logEvent.Properties)
            {
                var value = property.Value.ToString();

                foreach (var secret in blackList)
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