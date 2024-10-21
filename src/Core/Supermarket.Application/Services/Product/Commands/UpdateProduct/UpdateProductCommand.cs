using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Product.Commands.UpdateProduct
{
    public sealed record UpdateProductCommand(UpdateProductRequest UpdateProductRequest, Guid userId) : ICommand<Guid?>;
}
