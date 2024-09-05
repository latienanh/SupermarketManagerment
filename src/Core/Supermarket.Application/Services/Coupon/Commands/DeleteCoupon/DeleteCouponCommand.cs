using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Coupon.Commands.DeleteCoupon
{
    public sealed record DeleteCouponCommand(DeleteCouponRequest DeleteCouponRequest,Guid UserId) : ICommand<Guid?>;
}
