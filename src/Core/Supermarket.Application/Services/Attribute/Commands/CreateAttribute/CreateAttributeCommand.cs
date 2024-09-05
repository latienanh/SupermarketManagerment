using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Attribute.Commands.CreateAttribute
{
    public sealed record CreateAttributeCommand(CreateAttributeRequest attribute,Guid userId) : ICommand<Guid?>;
}
