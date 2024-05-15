namespace Samhammer.Logging;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public class LogDetails
{
    public Dictionary<string, object> Details { get; set; } = new Dictionary<string, object>();

    public LogDetails Add(string key, object value)
    {
        Details[key] = value;
        return this;
    }

    public LogDetails Add<T>(Expression<Func<T>> memberExpression)
    {
        var expressionBody = (MemberExpression)memberExpression.Body;
        return Add(expressionBody.Member.Name, memberExpression.Compile()());
    }
}
