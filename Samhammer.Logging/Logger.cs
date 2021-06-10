using System;

namespace Samhammer.Logging
{
    public static class Logger
    {
        private static Func<ILog> loggerFactory;
        
        public static void Init(Func<ILog> newLogger)
        {
            loggerFactory = newLogger;
        }

        public static ILog Log() => loggerFactory?.Invoke();
    }
}