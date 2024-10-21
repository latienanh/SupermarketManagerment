using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Category.Queries.SQLServerQueries.GetCategoryById
{
    public sealed record GetCategoryByIdQuery(Guid id) : IQuery<CategoryResponseDto>;

}
