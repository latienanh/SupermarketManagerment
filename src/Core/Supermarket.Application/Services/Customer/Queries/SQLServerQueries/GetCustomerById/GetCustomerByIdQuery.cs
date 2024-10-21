using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Customer.Queries.SQLServerQueries.GetCustomerById
{
    public sealed record GetCustomerByIdQuery(Guid id) : IQuery<CustomerResponseDto>;

}
