using LoggerExercise.Logger.Models;
using System.Collections.Generic;

namespace LoggerExercise.Logger.Configurations
{
    public class LoggerConfiguration
    {
        public List<LogLevel> LogLevels { get; set; }
        public List<LogType> LogTypes { get; set; }
    }
}