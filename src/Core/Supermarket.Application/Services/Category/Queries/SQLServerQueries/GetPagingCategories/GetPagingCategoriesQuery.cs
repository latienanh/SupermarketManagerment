using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Category.Queries.SQLServerQueries.GetPagingCategories
{
    public sealed record GetPagingCategoriesQuery(int index,int size) : IQuery<IEnumerable<CategoriesPagingResponseDto>>;

}
