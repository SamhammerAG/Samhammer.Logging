namespace Samhammer.Logging
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    public abstract class BaseLogger : ILog
    {
        protected abstract void Log(string message, LogDetails details, LogLevel loglevel, Exception ex);

        public void Verbose(string message, LogDetails details = null, Exception ex = null, string memberName = "",
            string sourceFilePath = "", int sourceLineNumber = 0)
        {
            Log(message, details, LogLevel.Verbose, ex);
        }

        public void Debug(string message, LogDetails details = null, Exception ex = null, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(message, details, LogLevel.Debug, ex);
        }

        public void Info(string message, LogDetails details = null, Exception ex = null, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(message, details, LogLevel.Information, ex);
        }

        public void Warn(string message, LogDetails details = null, Exception ex = null, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(message, details, LogLevel.Warning, ex);
        }

        public void Error(string message, LogDetails details = null, Exception ex = null, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(message, details, LogLevel.Error, ex);
        }

        public void Fatal(string message, LogDetails details = null, Exception ex = null, string memberName = "",
            string sourceFilePath = "", int sourceLineNumber = 0)
        {
            Log(message, details, LogLevel.Fatal, ex);
        }

        public void Log(string message, LogLevel logLevel, LogDetails details = null, Exception ex = null, string memberName = "",
            string sourceFilePath = "", int sourceLineNumber = 0)
        {
            details ??= new LogDetails();

            details.Add(LogMetadataFieldNames.MemberName, memberName)
                .Add(LogMetadataFieldNames.SourceFilePath, sourceFilePath)
                .Add(LogMetadataFieldNames.SourceLineNumber, sourceLineNumber);

            Log(message, details, logLevel, ex);
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
