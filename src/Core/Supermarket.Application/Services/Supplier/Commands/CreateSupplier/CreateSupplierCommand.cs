using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Supplier.Commands.CreateSupplier
{
    public sealed record CreateSupplierCommand(CreateSupplierRequest CreateSupplierRequest,Guid userId) : ICommand<Guid?>;
}
