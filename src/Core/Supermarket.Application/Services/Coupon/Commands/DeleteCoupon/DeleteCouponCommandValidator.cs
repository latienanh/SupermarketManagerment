using FluentValidation;

namespace Supermarket.Application.Services.Coupon.Commands.DeleteCoupon
{
    public class DeleteCouponCommandValidator : AbstractValidator<DeleteCouponRequest>
    {
        public DeleteCouponCommandValidator()
        {
            RuleFor(x=>x.Id ).NotEmpty();
        }
    }
}
