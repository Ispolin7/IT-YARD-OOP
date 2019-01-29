using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace IT_YARD.Common
{
    class FileLogger
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
            using (StreamWriter sw = new StreamWriter(GetFilePath(), true, Encoding.Default))
            {
                sw.WriteLine($"{DateTime.UtcNow} Type {Info}. Message: {message}");
                sw.Close();
            }
        }

        /// <summary>
        /// Print log error
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message)
        {
            using (StreamWriter sw = new StreamWriter(GetFilePath(), true, Encoding.Default))
            {
                sw.WriteLine($"{DateTime.UtcNow} Type {Error}. Message: {message}");
                sw.Close();
            }
        }

        /// <summary>
        /// Get path to log file
        /// </summary>
        /// <returns>path</returns>
        public string GetFilePath()
        {
            string path = Assembly.GetExecutingAssembly().Location;
            return path.Replace(@"bin\Debug\netcoreapp2.1\IT_YARD.dll", @"ApplicationData\log.txt");
            // System.IO.Path.GetFullPath(@"..\..\")
            // Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }
    }
}
