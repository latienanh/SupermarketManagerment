using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Attribute.Queries.MongoDBQueries.GetAllAttributes
{
    public sealed record GetAllAttributeQuery() : IQuery<IEnumerable<AttributeResponseDto>>;
}
