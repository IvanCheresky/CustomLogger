using Logger.Models;
using Logger.Services.Interfaces;
using System;

namespace Logger.Services
{
    public class ConsoleLogger : ILogger
    {
        public LogType LogType { get; set; } = LogType.Console;

        public void Log(LogLevel level, string message)
        {
            switch (level)
            {
                case LogLevel.Message:
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                case LogLevel.Warning:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case LogLevel.Error:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

            Console.WriteLine($"{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")} {level}: {message}");

            Console.ResetColor();
        }
    }
}