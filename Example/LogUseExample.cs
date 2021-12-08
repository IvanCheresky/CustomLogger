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
            // try logging to console
            //_loggingService.Log(LogT)
        }
    }
}