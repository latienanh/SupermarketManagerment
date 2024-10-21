using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Employee.Queries.SQLServerQueries.GetPagingEmployees
{
    public sealed record GetPagingEmployeesQuery(int index,int size) : IQuery<IEnumerable<EmployeeResponseDto>>;

}
