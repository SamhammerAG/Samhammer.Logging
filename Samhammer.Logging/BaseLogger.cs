namespace Samhammer.Logging
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    public abstract class BaseLogger : ILog
    {
        public abstract void Log(string message, LogDetails details, LogLevel loglevel, Exception ex, string memberName, string sourceFilePath, int sourceLineNumber);

        public void Verbose(string message, LogDetails details = null, Exception ex = null, string memberName = "",
            string sourceFilePath = "", int sourceLineNumber = 0)
        {
            Log(message, details, LogLevel.Verbose, ex, memberName, sourceFilePath, sourceLineNumber);
        }

        public void Debug(string message, LogDetails details = null, Exception ex = null, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(message, details, LogLevel.Debug, ex, memberName, sourceFilePath, sourceLineNumber);
        }

        public void Info(string message, LogDetails details = null, Exception ex = null, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(message, details, LogLevel.Information, ex, memberName, sourceFilePath, sourceLineNumber);
        }

        public void Warn(string message, LogDetails details = null, Exception ex = null, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(message, details, LogLevel.Warning, ex, memberName, sourceFilePath, sourceLineNumber);
        }

        public void Error(string message, LogDetails details = null, Exception ex = null, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(message, details, LogLevel.Error, ex, memberName, sourceFilePath, sourceLineNumber);
        }

        public void Fatal(string message, LogDetails details = null, Exception ex = null, string memberName = "",
            string sourceFilePath = "", int sourceLineNumber = 0)
        {
            Log(message, details, LogLevel.Fatal, ex, memberName, sourceFilePath, sourceLineNumber);
        }

        public void Log(string message, LogLevel logLevel, LogDetails details = null, Exception ex = null, string memberName = "",
            string sourceFilePath = "", int sourceLineNumber = 0)
        {
            Log(message, details, logLevel, ex, memberName, sourceFilePath, sourceLineNumber);
        }

        public LogDetails Add(string key, object value)
        {
            return new LogDetails().Add(key, value);
        }

        public LogDetails Add<T>(Expression<Func<T>> memberExpression)
        {
            var expressionBody = (MemberExpression)memberExpression.Body;
            return Add(expressionBody.Member.Name, memberExpression.Compile()());
        }
    }
}
