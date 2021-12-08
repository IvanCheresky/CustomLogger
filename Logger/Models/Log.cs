﻿using System;

namespace Logger.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string LogType { get; set; }
        public DateTime CreationDate { get; set; }
        public string Message { get; set; }
    }
}