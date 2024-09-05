using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Inventory.Commands.CreateProduct
{
    public sealed record CreateAttributeCommand(CreateAttributeRequest product,Guid userId) : ICommand<Guid>;
}
