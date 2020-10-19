namespace Samhammer.Logging
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    public abstract class BaseLogger : ILog
    {
        protected abstract void Log(string message, LogDetails details, LogLevel loglevel);

        public void Verbose(string message, LogDetails details = null, Exception ex = null, string memberName = "",
            string sourceFilePath = "", int sourceLineNumber = 0)
        {
            Log(message, LogLevel.Verbose, details, ex, memberName, sourceFilePath, sourceLineNumber);
        }

        public void Debug(string message, LogDetails details = null, Exception ex = null, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(message, LogLevel.Debug, details, ex, memberName, sourceFilePath, sourceLineNumber);
        }

        public void Info(string message, LogDetails details = null, Exception ex = null, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(message, LogLevel.Information, details, ex, memberName, sourceFilePath, sourceLineNumber);
        }

        public void Warn(string message, LogDetails details = null, Exception ex = null, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(message, LogLevel.Warning, details, ex, memberName, sourceFilePath, sourceLineNumber);
        }

        public void Error(string message, LogDetails details = null, Exception ex = null, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(message, LogLevel.Error, details, ex, memberName, sourceFilePath, sourceLineNumber);
        }

        public void Fatal(string message, LogDetails details = null, Exception ex = null, string memberName = "",
            string sourceFilePath = "", int sourceLineNumber = 0)
        {
            Log(message, LogLevel.Fatal, details, ex, memberName, sourceFilePath, sourceLineNumber);
        }

        public void Log(string message, LogLevel logLevel, LogDetails details = null, Exception ex = null, string memberName = "",
            string sourceFilePath = "", int sourceLineNumber = 0)
        {
            details ??= new LogDetails();

            //add possible exception and info about where the log was written into the logDetails
            details.Add(LogMetadataFieldNames.MemberName, memberName)
                .Add(LogMetadataFieldNames.SourceFilePath, sourceFilePath)
                .Add(LogMetadataFieldNames.SourceLineNumber, sourceLineNumber);

            if (ex != null)
            {
                details.Add(LogMetadataFieldNames.Exception, ex);
            }

            Log(message, details, logLevel);
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
