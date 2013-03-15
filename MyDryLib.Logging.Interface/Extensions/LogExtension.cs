using System;

namespace MyDryLib.Logging.Interface.Extensions
{
    /// <summary>
    /// convenience methods to any logger implementation
    /// </summary>
    /// <remarks>
    /// I don't want to implement any method for any kind of logger
    /// so I'll define most of that kind of stuff here.
    /// </remarks>
    public static class LogExtension
    {
        const String ExceptionLoggingFormat = "Exception: {0}, \n{1}";

        public static void LogTrace(this ILog logger, String message)
        {
            logger.LogAtLevel(LogLevel.Trace, message);
        }

        // ReSharper disable MethodOverloadWithOptionalParameter
        public static void LogTrace(this ILog logger, String format, params Object[] list)
        // ReSharper restore MethodOverloadWithOptionalParameter
        {
            logger.LogAtLevelFormatted(LogLevel.Trace, format, list);
        }

        public static void LogVerbose(this ILog logger, String message)
        {
            logger.LogAtLevel(LogLevel.Verbose, message);
        }

        // ReSharper disable MethodOverloadWithOptionalParameter
        public static void LogVerbose(this ILog logger, String format, params Object[] list)
        // ReSharper restore MethodOverloadWithOptionalParameter
        {
            logger.LogAtLevelFormatted(LogLevel.Verbose, format, list);
        }

        public static void LogWarning(this ILog logger, String message)
        {
            logger.LogAtLevel(LogLevel.Warning, message);
        }

        // ReSharper disable MethodOverloadWithOptionalParameter
        public static void LogWarning(this ILog logger, String format, params Object[] list)
        // ReSharper restore MethodOverloadWithOptionalParameter
        {
            logger.LogAtLevelFormatted(LogLevel.Warning, format, list);
        }

        public static void LogError(this ILog logger, String message)
        {
            logger.LogAtLevel(LogLevel.Error, message);
        }

        // ReSharper disable MethodOverloadWithOptionalParameter
        public static void LogError(this ILog logger, String format, params Object[] list)
        // ReSharper restore MethodOverloadWithOptionalParameter
        {
            logger.LogAtLevelFormatted(LogLevel.Error, format, list);
        }

        public static void LogAtLevelFormatted(this ILog logger, LogLevel level, String format, params Object[] args)
        {
            var message = String.Format(format, args);
            logger.LogAtLevel(level, message);
        }

        /// <summary>
        /// log exception with stack trace as error
        /// </summary>
        /// <param name="logger">logger instance</param>
        /// <param name="exception">exception to log</param>
        public static void LogException(this ILog logger, Exception exception)
        {
            logger.LogAtLevelFormatted(LogLevel.Error, ExceptionLoggingFormat, exception.ToString(), exception.StackTrace);
        }
    }
}
