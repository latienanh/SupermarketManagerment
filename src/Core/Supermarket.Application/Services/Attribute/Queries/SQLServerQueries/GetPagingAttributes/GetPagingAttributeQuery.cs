using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Attribute.Queries.SQLServerQueries.GetPagingAttributes
{
    public sealed record GetPagingAttributeQuery(int index,int size) : IQuery<IEnumerable<AttributeResponseDto>>;

}
