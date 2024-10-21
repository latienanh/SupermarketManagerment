using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Product.Commands.DeleteProduct
{
    public sealed record DeleteProductCommand(DeleteProductRequest DeleteProductRequest,Guid UserId) : ICommand<Guid?>
    {
    }
}
