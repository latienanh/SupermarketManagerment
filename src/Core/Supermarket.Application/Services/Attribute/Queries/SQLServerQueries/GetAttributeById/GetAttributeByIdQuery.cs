using MediatR;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Attribute.Queries.SQLServerQueries.GetAttributeById
{
    public sealed record GetAttributeByIdQuery(Guid id) : IQuery<AttributeResponseDto>;

}
