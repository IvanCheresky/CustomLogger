using System.Collections.Generic;
using Logger.Models;

namespace Logger.Configurations
{
    public interface ILoggerConfiguration
    {
        public List<LogLevel> LogLevels { get; set; }
        public List<LogTypes> LogTypes { get; set; }
    }
}