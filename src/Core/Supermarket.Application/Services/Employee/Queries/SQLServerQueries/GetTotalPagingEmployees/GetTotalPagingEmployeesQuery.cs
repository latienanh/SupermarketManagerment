using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Employee.Queries.SQLServerQueries.GetTotalPagingEmployees
{
    public sealed record GetTotalPagingEmployeesQuery(int size) : IQuery<int>;

}
