using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Authentication.Commands.Logout
{
    public sealed record LogoutCommand(LogoutRequest LogoutRequest) : ICommand<Guid?>
    {
    }
}
