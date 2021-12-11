using Logger.Models;
using System.Collections.Generic;

namespace Logger.Configurations
{
    public class LoggerConfiguration
    {
        public List<LogLevel> LogLevels { get; set; }
        public List<LogType> LogTypes { get; set; }
    }
}