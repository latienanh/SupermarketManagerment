using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Authentication.Commands.Logout
{
    public sealed record DeleteAttributeCommand(Guid Id,Guid UserId) : ICommand<Guid>
    {
    }
}
