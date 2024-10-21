using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Category.Commands.Queries.MongoDBQueries.GetAllAttributes
{
    public sealed record GetAllAttributeQuery() : IQuery<IEnumerable<AttributeResponseDto>>;
}
