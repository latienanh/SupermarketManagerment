namespace Supermarket.Application.Services.Authentication.Commands.Login
{
    public sealed record LoginRequest
    {
            public string UserName { get; set; }
            public string Password { get; set; }
        
    }
}
