using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Coupon.Queries.SQLServerQueries.GetAllCoupons
{
    public sealed record GetAllCouponsQuery() : IQuery<IEnumerable<CouponResposeDto>>;
}
