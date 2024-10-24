﻿using FluentValidation;

namespace Supermarket.Application.Services.Coupon.Commands.UpdateCoupon
{
    public class UpdateCouponCommandValidator : AbstractValidator<UpdateCouponRequest>
    {
        public UpdateCouponCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
