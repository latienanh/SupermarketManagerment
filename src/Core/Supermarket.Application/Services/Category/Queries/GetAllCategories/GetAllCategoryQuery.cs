using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Category.Queries.GetAllCategories
{
    public sealed record GetAllAttributeQuery() : IQuery<IEnumerable<ProductResponseDto>>;
}
