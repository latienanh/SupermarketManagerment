using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.MemberShipType.Queries.SQLServerQueries.GetPagingMemberShipTypes
{
    public sealed record GetPagingMemberShipTypesQuery(int index,int size) : IQuery<IEnumerable<MemberShipTypeResposeDto>>;

}
