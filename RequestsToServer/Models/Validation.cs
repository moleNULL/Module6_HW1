﻿namespace RequestsToServer.Models
{
    public abstract class Validation
    {
        public string? Error { get; set; }
        public string? ErrorCode { get; set; }
    }
}