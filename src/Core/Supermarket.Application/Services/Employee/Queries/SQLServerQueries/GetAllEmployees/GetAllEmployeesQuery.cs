using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Employee.Queries.SQLServerQueries.GetAllEmployees
{
    public sealed record GetAllEmployeesQuery() : IQuery<IEnumerable<EmployeeResponseDto>>;
}
