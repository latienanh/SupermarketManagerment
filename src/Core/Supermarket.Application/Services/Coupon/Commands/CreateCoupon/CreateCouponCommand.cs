using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Coupon.Commands.CreateCoupon
{
    public sealed record CreateCouponCommand(CreateCouponRequest CreateCouponRequest,Guid UserId) : ICommand<Guid?>;
}
