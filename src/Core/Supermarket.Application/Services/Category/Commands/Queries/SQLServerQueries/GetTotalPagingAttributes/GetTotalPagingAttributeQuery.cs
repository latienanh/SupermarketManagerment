using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Category.Commands.Queries.SQLServerQueries.GetTotalPagingAttributes
{
    public sealed record GetTotalPagingCategoriesQuery(int size) : IQuery<int>;

}
