using System.Collections.Generic;
using Logger.Models;

namespace Logger.Services.Interfaces
{
    public interface ILoggingService
    {
        void Log(LogLevel logLevel, string message);
        void ForceLog(LogLevel logLevel, List<LogType> logTypes, string message);
    }
}