namespace Samhammer.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class LogDetails
    {
        public Dictionary<string, object> Details { get; set; } = new Dictionary<string, object>();

        public LogDetails Add(string key, object value)
        {
            if (Details.TryGetValue(key, out _))
            {
                if (Details[key] != value)
                {
                    Details[key] = value;
                }
                else
                {
                    var details = new LogDetails();
                    details.Add("StackTrace", Environment.StackTrace);
                    details.Add("Key", key);
                    details.Add("Value", value);
                    
                    Logger.Log()?.Warn("Tried to insert duplicate key to log details!", null, details);
                }
            }
            else
            {
                Details.Add(key, value);
            }

            return this;
        }

        public LogDetails Add<T>(Expression<Func<T>> memberExpression)
        {
            var expressionBody = (MemberExpression)memberExpression.Body;
            return Add(expressionBody.Member.Name, memberExpression.Compile()());
        }
    }
}
