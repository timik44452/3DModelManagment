using System;
using MiddlewareAPI;

namespace ModelServer
{
    public class ConsoleLogger : ILogger
    {
        public void ErrorMessage(object msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"({DateTime.Now.ToString("g")}) Error:{msg.ToString()}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void LogMessage(object msg)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"({DateTime.Now.ToString("g")}) Log:{msg.ToString()}");
        }

        public void WarningMessage(object msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"({DateTime.Now.ToString("g")}) Warning:{msg.ToString()}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
