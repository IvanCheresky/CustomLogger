using System;
using Logger.Models;
using Logger.Services.Interfaces;

namespace Logger.Services
{
    public class ConsoleLogger : ILogger
    {
        public LogType LogType { get; set; } = LogType.Console;

        public void Log(LogLevel level, string message)
        {
            Console.WriteLine($"{level}: {message}");
        }
    }
}