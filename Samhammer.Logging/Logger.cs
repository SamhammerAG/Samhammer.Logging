using System;

namespace Samhammer.Logging
{
    public static class Logger
    {
        private static Func<ILog> loggerFactory;
        
        /// <summary>
        /// Initializes logger factory;
        /// </summary>
        /// <param name="newLogger">Logger</param>
        /// <param name="fallbackLogType">LogType which is used when no other LogType is provided.</param>
        public static void Init(Func<ILog> newLogger)
        {
            loggerFactory = newLogger;
        }

        public static ILog Log() => loggerFactory?.Invoke();
    }
}