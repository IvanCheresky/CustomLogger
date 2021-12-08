using Logger.Models;

namespace Logger.Services.Interfaces
{
    public interface ILogger
    {
        LogType LogType { get; set; }

        void Log(LogLevel level, string message);
    }
}