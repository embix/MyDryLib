using System;
using System.IO;
using MyDryLib.Logging.Interface;

namespace MyDryLib.Logging.Common
{
    /// <summary>
    /// logger implementation that uses a TextWriter as backend to log to
    /// </summary>
    public class TextLogger : ILog
    {
        private readonly TextWriter _writer;


        public TextLogger(TextWriter writer)
        {
            if (writer == null) throw new ArgumentNullException("writer");

            _writer = writer;
        }

        /// <summary>
        /// uses <see cref="System.Console.Out"/> as logging backend
        /// </summary>
        public TextLogger() : this(Console.Out){}

        public void LogAtLevel(LogLevel level, String message)
        {
            String entry = String.Format("{0}: {1}", level, message);
            _writer.WriteLine(entry);
        }
    }
}
