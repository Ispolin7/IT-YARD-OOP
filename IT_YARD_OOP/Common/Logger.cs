using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD.Common
{
    /// <summary>
    /// Log perository operations and errors
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Class constants
        /// </summary>
        private const string Info = "Info";
        private const string Error = "error";

        /// <summary>
        /// Print log info
        /// </summary>
        /// <param name="message"></param>
        public void LogInfo(string message)
        {
            Console.WriteLine($"{DateTime.UtcNow} Type {Info}. Message: {message}");
        }

        /// <summary>
        /// Print log error
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message)
        {
            Console.WriteLine($"{DateTime.UtcNow} Type {Error}. Message: {message}");
        }
    }
}
