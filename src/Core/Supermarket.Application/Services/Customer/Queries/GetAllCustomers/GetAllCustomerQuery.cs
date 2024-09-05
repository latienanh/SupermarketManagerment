using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Customer.Queries.GetAllCustomers
{
    public sealed record GetAllAttributeQuery() : IQuery<IEnumerable<ProductResponseDto>>;
}
