using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Inventory.Queries.GetAllProducts
{
    public sealed record GetAllAttributeQuery() : IQuery<IEnumerable<ProductResponseDto>>;
}
