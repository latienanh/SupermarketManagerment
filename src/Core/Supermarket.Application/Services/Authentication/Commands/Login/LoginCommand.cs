using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Authentication.Commands.Login
{
    public sealed record LoginCommand(LoginRequest LoginRequest) : ICommand<LoginResponse?>;
}
