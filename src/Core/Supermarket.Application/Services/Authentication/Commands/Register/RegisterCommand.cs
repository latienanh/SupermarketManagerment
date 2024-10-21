using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Authentication.Commands.Register
{
    public sealed record RegisterCommand(RegisterRequest registerRequest): ICommand<Guid?>
    {
    }
}
