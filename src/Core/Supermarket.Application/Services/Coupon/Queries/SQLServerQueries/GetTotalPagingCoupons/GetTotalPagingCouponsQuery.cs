using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Coupon.Queries.SQLServerQueries.GetTotalPagingCoupons
{
    public sealed record GetTotalPagingCouponsQuery(int size) : IQuery<int>;

}
