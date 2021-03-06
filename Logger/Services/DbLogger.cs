using Logger.Data.Interfaces;
using Logger.Models;
using Logger.Services.Interfaces;
using System;

namespace Logger.Services
{
    public class DbLogger : ILogger
    {
        public LogType LogType { get; set; } = LogType.Db;

        private readonly ILogRepository _logRepository;

        public DbLogger(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void Log(LogLevel level, string message)
        {
            var log = new Log()
            {
                CreationDate = DateTime.UtcNow,
                LogType = LogType,
                LogLevel = level,
                Message = message
            };

            _logRepository.Add(log);
        }
    }
}