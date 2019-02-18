using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace IT_YARD.Common
{
    public static class Logger
    {
        /// <summary>
        /// Class constants
        /// </summary>
        private const string Info = "Info";
        private const string Error = "error";
        private static string FilePath { get; }
 
        static Logger()
        {
            FilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "\\ApplicationData\\log.txt";
        }
        /// <summary>
        /// Print log info
        /// </summary>
        /// <param name="message"></param>
        public static void LogInfo(string message)
        {
            using (StreamWriter sw = new StreamWriter(FilePath, true, Encoding.Default))
            {
                sw.WriteLine($"{DateTime.UtcNow} Type {Info}. Message: {message}");
                sw.Close();
            }
        }

        /// <summary>
        /// Print log error
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(string message)
        {
            using (StreamWriter sw = new StreamWriter(FilePath, true, Encoding.Default))
            {
                sw.WriteLine($"{DateTime.UtcNow} Type {Error}. Message: {message}");
                sw.Close();
            }
        }
    }
}
