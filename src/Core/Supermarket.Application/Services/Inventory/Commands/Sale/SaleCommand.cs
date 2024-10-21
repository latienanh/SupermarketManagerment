using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services.Inventory.Commands.Sale
{
    public sealed record SaleCommand(InvoiceRequest InvoiceRequest,Guid UserId) : ICommand<Guid?>
    {
    }
}
