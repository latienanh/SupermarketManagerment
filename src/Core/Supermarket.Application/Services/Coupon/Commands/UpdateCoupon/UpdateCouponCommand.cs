using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.Services.Category.Commands.UpdateCategory;

namespace Supermarket.Application.Services.Coupon.Commands.UpdateCoupon
{
    public sealed record UpdateCouponCommand
        (UpdateCouponRequest UpdateCouponRequest, Guid UserId) : ICommand<Guid?>
    {
    };
}
