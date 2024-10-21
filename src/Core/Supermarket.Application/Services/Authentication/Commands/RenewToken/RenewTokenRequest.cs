namespace Supermarket.Application.Services.Authentication.Commands.RenewToken
{
    public sealed record RenewTokenRequest(string AccessToken, string RefreshToken);
}
