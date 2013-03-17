using System;
using System.Collections.Generic;
using MyDryLib.Logging.Interface;

namespace MyDryLib.Logging.Common
{
    /// <summary>
    /// abstraction to multiple logging backends
    /// </summary>
    /// <list type="bullet">
    /// <item>changeable at runtime</item>
    /// <item>preserves order</item>
    /// </list>
    /// <remarks>
    /// remember to not build any loops when connecting loggers 
    /// </remarks>
    public class MultiLogger : ILog
    {
        private readonly Object _locker = new Object();
        private readonly List<ILog> _loggers;
        
        public MultiLogger()
        {
            _loggers = new List<ILog>();
        }

        /// <summary>
        /// attach logger as additional backend
        /// </summary>
        /// <param name="logger">logger implementation</param>
        public void AttachLogger(ILog logger)
        {
            if (logger == null) throw new ArgumentNullException("logger");

            lock (_locker)
            {
                _loggers.Add(logger);
            }
        }

        /// <summary>
        /// detach logger as additional backend
        /// </summary>
        /// <param name="logger"></param>
        public void DetachLogger(ILog logger)
        {
            if (logger == null) throw new ArgumentNullException("logger");

            lock (_locker)
            {
                _loggers.Remove(logger);
            }
        }

        public void LogAtLevel(LogLevel level, String message)
        {
            lock (_locker)
            {
                foreach (var logger in _loggers)
                {
                    logger.LogAtLevel(level, message);
                }
            }
        }
    }
}
