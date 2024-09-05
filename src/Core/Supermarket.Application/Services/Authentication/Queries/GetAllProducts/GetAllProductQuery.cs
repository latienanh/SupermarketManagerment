using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Authentication.Queries.GetAllProducts
{
    public sealed record GetAllAttributeQuery() : IQuery<IEnumerable<ProductResponseDto>>;
}
