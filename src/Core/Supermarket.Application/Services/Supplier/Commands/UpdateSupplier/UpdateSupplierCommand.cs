using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Supplier.Commands.UpdateSupplier
{
    public sealed record UpdateSupplierCommand(UpdateSupplierRequest UpdateSupplierRequest,Guid UserId) : ICommand<Guid?>
    {
    }
}
