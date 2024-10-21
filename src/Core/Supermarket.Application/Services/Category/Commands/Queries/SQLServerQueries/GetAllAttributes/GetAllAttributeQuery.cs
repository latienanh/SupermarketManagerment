using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Category.Commands.Queries.SQLServerQueries.GetAllAttributes
{
    public sealed record GetAllCategoriesQuery() : IQuery<IEnumerable<AttributeResponseDto>>;
}
