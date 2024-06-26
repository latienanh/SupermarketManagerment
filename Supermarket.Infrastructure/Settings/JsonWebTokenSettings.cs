﻿namespace Supermarket.Infrastructure.Settings;

public class JsonWebTokenSettings
{
    public const string SettingName = "JsonWebToken";
    public string ValidIssuer { get; set; }
    public string ValidAudience { get; set; }
    public string SecretKey { get; set; }
}