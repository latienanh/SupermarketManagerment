using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Coupon.Queries.SQLServerQueries.GetCouponById
{
    public sealed record GetCouponByIdQuery(Guid id) : IQuery<CouponResposeDto>;

}
