using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.MemberShipType.Queries.SQLServerQueries.GetAllMemberShipTypes
{
    public sealed record GetAllMemberShipTypesQuery() : IQuery<IEnumerable<MemberShipTypeResposeDto>>;
}
