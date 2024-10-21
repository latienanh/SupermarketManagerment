using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Customer.Queries.SQLServerQueries.GetTotalPagingCustomers
{
    public sealed record GetTotalPagingCustomersQuery(int size) : IQuery<int>;

}
