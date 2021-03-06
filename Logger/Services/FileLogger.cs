using Logger.Models;
using Logger.Services.Interfaces;
using System;
using System.IO;

namespace Logger.Services
{
    public class FileLogger : ILogger
    {
        public LogType LogType { get; set; } = LogType.File;

        public void Log(LogLevel level, string message)
        {
            File.WriteAllText($"{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss")}.txt", $"{level}: {message}");
        }
    }
}