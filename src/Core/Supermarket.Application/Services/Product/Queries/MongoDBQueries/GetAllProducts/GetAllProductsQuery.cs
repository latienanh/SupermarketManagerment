using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Product.Queries.MongoDBQueries.GetAllProducts
{
    public sealed record GetAllProductsQuery() : IQuery<IEnumerable<AttributeResponseDto>>;
}
