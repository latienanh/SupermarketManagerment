namespace Supermarket.Application.ModelRequests;

public class LoginTokenRequest
{
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }
    //public DateTime ExpirationRT { get; set; }
}