using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Product.Queries.SQLServerQueries.GetAllProducts
{
    public sealed record GetAllProductsQuery() : IQuery<IEnumerable<ProductResponseDto>>;
}
