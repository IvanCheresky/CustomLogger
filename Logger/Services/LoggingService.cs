using System;
using System.Collections.Generic;
using Logger.Configurations;
using Logger.Models;
using Logger.Services.Interfaces;

namespace Logger.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly ILoggerConfiguration _configuration;

        public LoggingService(ILoggerConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Log(LogLevel logLevel, string Message)
        {
            if (!_configuration.LogLevels.Contains(logLevel))
            {
                return;
            }

            foreach (var type in _configuration.LogTypes)
            {
                Console.WriteLine(type.ToString());
            }
        }

        // overrides configuration
        public void ForceLog(LogLevel logLevel, List<LogTypes> logTypes, string Message)
        {

        }
    }
}