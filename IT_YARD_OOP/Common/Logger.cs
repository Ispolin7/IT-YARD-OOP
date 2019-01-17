using System;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD_OOP.Common
{
    public class Logger
    {
        private const string Info = "Info";
        private const string error = "error";

        public void LogInfo(string message)
        {
            Console.WriteLine($"Type {Info}. Message: {message}");
        }

        //public void LogError(string message)
        //{
        //    Console.WriteLine(message);
        //}
    }
}
