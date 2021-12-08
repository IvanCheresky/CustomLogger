using LoggerExercise.Logger.Models;
using LoggerExercise.Logger.Services.Interfaces;
using System;

namespace LoggerExercise.Logger.Services
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