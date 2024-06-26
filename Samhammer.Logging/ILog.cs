﻿namespace Samhammer.Logging;

using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

public interface ILog
{
    void Verbose(string message, BaseLogType logType, LogDetails details = null, Exception ex = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0);

    void Debug(string message, BaseLogType logType, LogDetails details = null, Exception ex = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0);

    void Info(string message, BaseLogType logType, LogDetails details = null, Exception ex = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0);

    void Warn(string message, BaseLogType logType, LogDetails details = null, Exception ex = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0);

    void Error(string message, BaseLogType logType, LogDetails details = null, Exception ex = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0);

    void Fatal(string message, BaseLogType logType, LogDetails details = null, Exception ex = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0);

    void Log(string message, BaseLogType logType, LogLevel logLevel, LogDetails details = null, Exception ex = null,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0);


    LogDetails Add(string key, object value);

    LogDetails Add<T>(Expression<Func<T>> memberExpression);
}