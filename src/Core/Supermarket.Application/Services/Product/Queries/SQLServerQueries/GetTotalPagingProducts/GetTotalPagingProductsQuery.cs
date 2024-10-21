using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Product.Queries.SQLServerQueries.GetTotalPagingProducts
{
    public sealed record GetTotalPagingProductsQuery(int size) : IQuery<int>;

}
