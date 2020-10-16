using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Serilog.Context;

namespace Samhammer.Logging.Serilog
{
    public class SerilogLogger : BaseLogger
    {
        protected override void Log(string message, LogDetails details, LogLevel loglevel)
        {
            LogWithDetails(() => global::Serilog.Log.Write(loglevel.ToSerilogLogLevel(), message), details);
        }

        private void LogWithDetails(Action logAction, LogDetails details = null)
        {
            var disposables = new List<IDisposable>();

            if (details == null)
            {
                logAction();
                return;
            }

            foreach (var detailsKey in details.Details.Keys)
            {
                var value = details.Details[detailsKey];
                string serializedValue;

                if (value is string s)
                {
                    serializedValue = s;
                }
                else
                {
                    serializedValue = JsonConvert.SerializeObject(value, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                }

                disposables.Add(LogContext.PushProperty(detailsKey, serializedValue));
            }

            logAction();
            disposables.Reverse();
            disposables.ForEach(x => x.Dispose());
        }
    }
}
