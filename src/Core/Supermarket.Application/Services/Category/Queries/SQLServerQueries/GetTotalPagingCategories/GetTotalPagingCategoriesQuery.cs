using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Category.Queries.SQLServerQueries.GetTotalPagingCategories
{
    public sealed record GetTotalPagingCategoriesQuery(int size) : IQuery<int>;

}
