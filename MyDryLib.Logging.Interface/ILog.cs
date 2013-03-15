using System;

namespace MyDryLib.Logging.Interface
{
    /// <summary>
    /// abstraction for basic logging backend
    /// </summary>
    public interface ILog
    {
        void LogAtLevel(LogLevel level, String message);
    }
}
