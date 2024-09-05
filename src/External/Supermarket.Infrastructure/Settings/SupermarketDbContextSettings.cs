namespace Supermarket.Infrastructure.Settings;

public class SupermarketDbContextSettings
{
    public const string SettingName = "ConnectionStrings";
    public string DefaultConnection { get; set; }
}