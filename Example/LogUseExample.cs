using LoggerExercise.Logger.Models;
using LoggerExercise.Logger.Services.Interfaces;

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
            _loggingService.Log(LogLevel.Message, "Testing message using configuration");
        }
    }
}