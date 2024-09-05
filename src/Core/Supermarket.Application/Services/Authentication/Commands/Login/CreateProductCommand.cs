using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Authentication.Commands.Login
{
    public sealed record CreateAttributeCommand(CreateAttributeRequest product,Guid userId) : ICommand<Guid>;
}
