using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Product.Queries.SQLServerQueries.GeProductById
{
    public sealed record GetProductByIdQuery(Guid id) : IQuery<ProductResponseDto>;

}
