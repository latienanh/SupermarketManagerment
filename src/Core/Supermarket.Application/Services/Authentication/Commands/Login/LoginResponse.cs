namespace Supermarket.Application.Services.Authentication.Commands.Login
{
    public sealed class LoginResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
