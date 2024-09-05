using FluentValidation;

namespace Supermarket.Application.Services.Coupon.Commands.CreateCoupon
{
    public class CreateCouponCommandValidator : AbstractValidator<CreateCouponRequest>
    {
        public CreateCouponCommandValidator()
        {
            RuleFor(x=>x.Code).NotEmpty();
            RuleFor(x => x.CouponDescripiton).NotEmpty();
        }
    }
}
