using System.Collections.Generic;
using Logger.Models;

namespace Logger.Configurations
{
    public class LoggerConfiguration
    {
        public List<LogLevel> LogLevels { get; set; }
        public List<LogType> LogTypes { get; set; }
    }
}