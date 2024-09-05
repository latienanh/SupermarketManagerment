using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Supplier.Commands.DeleteSupplier
{
    public sealed record DeleteSupplierCommand(DeleteSupplierRequest DeleteSupplierRequest,Guid UserId) : ICommand<Guid?>
    {
    }
}
