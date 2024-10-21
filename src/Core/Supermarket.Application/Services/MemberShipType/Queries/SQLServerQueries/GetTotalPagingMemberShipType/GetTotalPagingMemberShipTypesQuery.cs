using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.MemberShipType.Queries.SQLServerQueries.GetTotalPagingMemberShipType
{
    public sealed record GetTotalPagingMemberShipTypesQuery(int size) : IQuery<int>;

}
