using System;

namespace Samhammer.Logging;

public static class Logger
{
    private static Func<ILog> _loggerFactory;

    /// <summary>
    /// Initializes logger factory;
    /// </summary>
    /// <param name="newLogger">Logger</param>
    public static void Init(Func<ILog> newLogger)
    {
        _loggerFactory = newLogger;
    }

    public static ILog Log() => _loggerFactory?.Invoke();
}
