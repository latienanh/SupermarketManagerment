using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Customer.Queries.SQLServerQueries.GetPagingCustomers
{
    public sealed record GetPagingCustomersQuery(int index,int size) : IQuery<IEnumerable<CustomerResponseDto>>;

}
