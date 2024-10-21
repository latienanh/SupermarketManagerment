using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Product.Commands.CreateProduct
{
    public sealed record CreateProductCommand(CreateProductRequest product,Guid userId) : ICommand<Guid?>;
}
