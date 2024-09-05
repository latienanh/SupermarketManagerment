using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Inventory.Commands.DeleteProduct
{
    public sealed record DeleteAttributeCommand(Guid Id,Guid UserId) : ICommand<Guid>
    {
    }
}
