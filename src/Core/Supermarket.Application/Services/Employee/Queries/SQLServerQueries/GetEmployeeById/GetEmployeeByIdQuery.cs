using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Employee.Queries.SQLServerQueries.GetEmployeeById
{
    public sealed record GetEmployeeByIdQuery(Guid id) : IQuery<EmployeeResponseDto>;

}
