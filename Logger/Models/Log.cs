using System;

namespace Logger.Models
{
    public class Log
    {
        public int Id { get; set; }
        public LogType LogType { get; set; }
        public LogLevel LogLevel { get; set; }
        public DateTime CreationDate { get; set; }
        public string Message { get; set; }
    }
}