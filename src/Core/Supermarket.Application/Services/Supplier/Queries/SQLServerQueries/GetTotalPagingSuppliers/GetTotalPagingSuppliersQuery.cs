using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Supplier.Queries.SQLServerQueries.GetTotalPagingSuppliers
{
    public sealed record GetTotalPagingSuppliersQuery(int size) : IQuery<int>;

}
