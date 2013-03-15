using System;

namespace MyDryLib.Logging.Interface
{
    /// <summary>
    /// simple implementation if you don't want to provide
    /// a logger implementation when using my lib
    /// </summary>
    public class DevNullLogger : ILog
    {
        public void LogAtLevel(LogLevel level, String message){}
    }
}
