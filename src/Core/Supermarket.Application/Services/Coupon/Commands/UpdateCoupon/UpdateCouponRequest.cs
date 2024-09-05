using Supermarket.Application.Common;

namespace Supermarket.Application.Services.Coupon.Commands.UpdateCoupon
{
    public sealed record UpdateCouponRequest : BaseDTORequestUpdate
    {
        public string? Code { get; set; }
        public string? CouponDescripiton { get; set; }
        public double? DiscountValue { get; set; }
        public int? DiscountType { get; set; }
        public DateTime? CouponStartDate { get; set; }
        public DateTime? CouponEndDate { get; set; }
    }
}
