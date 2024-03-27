namespace Supermarket.Application.ModelResponses;

public class LoginResponses
{
    public string AccessToken { get; set; }
    public DateTime ExpirationAT { get; set; }
    public string RefreshToken { get; set; }
    public DateTime ExpirationRT { get; set; }
}