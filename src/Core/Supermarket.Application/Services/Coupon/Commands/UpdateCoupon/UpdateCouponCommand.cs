using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Coupon.Commands.UpdateCoupon
{
    public sealed record UpdateCouponCommand
        (UpdateCouponRequest UpdateCouponRequest, Guid UserId) : ICommand<Guid?>
    {
    };
}
