using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.Services.Authentication.Commands.Login;

namespace Supermarket.Application.Services.Authentication.Commands.RenewToken
{
    public sealed record RenewTokenCommand(RenewTokenRequest RenewTokenRequest) : ICommand<LoginResponse?>;
}
