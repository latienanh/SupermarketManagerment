using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Attribute.Queries.SQLServerQueries.GetTotalPagingAttributes
{
    public sealed record GetTotalPagingAttributeQuery(int size) : IQuery<int>;

}
