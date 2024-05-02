﻿namespace Sigim.Application.Models.Settings
{
    public class JwtSettings
    {
        public string Key { get; set; } = string.Empty;
        public int? DurationInMinutes { get; set; }
    }
}
