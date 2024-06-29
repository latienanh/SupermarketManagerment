namespace Supermarket.Application.DTOs.Auth.RequestDtos
{
    public class LoginTokenRequestDtos
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
