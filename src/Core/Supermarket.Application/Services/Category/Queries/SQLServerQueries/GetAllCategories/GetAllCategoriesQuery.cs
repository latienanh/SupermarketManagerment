using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Category.Queries.SQLServerQueries.GetAllCategories
{
    public sealed record GetAllCategoriesQuery() : IQuery<IEnumerable<CategoryResponseDto>>;
}
