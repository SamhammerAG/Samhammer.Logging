using System;

namespace Samhammer.Logging
{
    public static class Logger
    {
        private static Func<ILog> loggerFactory;
        private static BaseLogType fallback;
        
        /// <summary>
        /// Initializes logger factory;
        /// </summary>
        /// <param name="newLogger">Logger</param>
        /// <param name="fallbackLogType">LogType which is used when no other LogType is provided.</param>
        public static void Init(Func<ILog> newLogger, BaseLogType fallbackLogType)
        {
            loggerFactory = newLogger;
            fallback = fallbackLogType;
        }

        public static ILog Log() => loggerFactory?.Invoke();

        /// <summary>
        /// Returns fallback LogType which is used when no other LogType is provided.
        /// </summary>
        /// <returns></returns>
        public static BaseLogType GetFallbackLogType() => fallback;
    }
}