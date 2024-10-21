using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Customer.Queries.SQLServerQueries.GetAllCustomers
{
    public sealed record GetAllCustomersQuery() : IQuery<IEnumerable<CustomerResponseDto>>;
}
