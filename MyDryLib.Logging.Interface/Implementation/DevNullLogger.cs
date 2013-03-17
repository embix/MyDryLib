using System;

namespace MyDryLib.Logging.Interface.Implementation
{
    /// <summary>
    /// to reduce dependencies when using libs referencing
    /// only the interface part of MyDryLib.Logging
    /// a non-logging logger implementation is given here
    /// </summary>
    public class DevNullLogger : ILog
    {
        public void LogAtLevel(LogLevel level, String message){}
    }
}
