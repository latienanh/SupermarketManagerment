using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Category.Commands.Queries.SQLServerQueries.GetAttributeById
{
    public sealed record GetCategoryByIdQuery(Guid id) : IQuery<AttributeResponseDto>;

}
