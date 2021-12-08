using System.Collections.Generic;
using Logger.Configurations;
using Logger.Models;
using Logger.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Logger.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly LoggerConfiguration _configuration;
        private readonly IEnumerable<ILogger> _loggers;

        public LoggingService(IOptions<LoggerConfiguration> configuration, IEnumerable<ILogger> loggers)
        {
            _configuration = configuration.Value;
            _loggers = loggers;
        }

        public void Log(LogLevel logLevel, string message)
        {
            if (_configuration.LogLevels.Contains(logLevel))
            {
                foreach (var logger in _loggers)
                {
                    if (_configuration.LogTypes.Contains(logger.LogType))
                    {
                        logger.Log(logLevel, message);
                    }
                }
            }
        }

        // overrides configuration
        public void ForceLog(LogLevel logLevel, List<LogType> logTypes, string message)
        {
            foreach (var logger in _loggers)
            {
                if (logTypes.Contains(logger.LogType))
                {
                    logger.Log(logLevel, message);
                }
            }
        }
    }
}