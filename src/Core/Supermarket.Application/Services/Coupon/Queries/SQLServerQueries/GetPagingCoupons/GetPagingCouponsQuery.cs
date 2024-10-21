using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Coupon.Queries.SQLServerQueries.GetPagingCoupons
{
    public sealed record GetPagingCouponsQuery(int index,int size) : IQuery<IEnumerable<CouponResposeDto>>;

}
