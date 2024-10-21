using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.MemberShipType.Queries.SQLServerQueries.GetMemberShipTypeById
{
    public sealed record GetMemberShipTypeByIdQuery(Guid id) : IQuery<MemberShipTypeResposeDto>;

}
