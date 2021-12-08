using System.Collections.Generic;
using Logger.Models;
using Logger.Services.Interfaces;

namespace LoggerExercise.Example
{
    public class LogUseExample : ILogUseExample
    {
        private readonly ILoggingService _loggingService;

        public LogUseExample(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public void UseLogger()
        {
            // should print to console, file and db (if appsettings wasn't changed)
            _loggingService.Log(LogLevel.Message, "Testing message using configuration");

            // should print to console, file and db (if appsettings wasn't changed)
            _loggingService.Log(LogLevel.Error, "Testing error using configuration");

            // shouldn't print anywhere (if appsettings wasn't changed)
            _loggingService.Log(LogLevel.Warning, "Testing warning using configuration");

            // should override configuration and print to console and db
            _loggingService.ForceLog(LogLevel.Warning, new List<LogType>() { LogType.Console, LogType.Db }, "Testing warning overriding configuration");
        }
    }
}