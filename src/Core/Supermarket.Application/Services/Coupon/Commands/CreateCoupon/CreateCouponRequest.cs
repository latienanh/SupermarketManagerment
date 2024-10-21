namespace Supermarket.Application.Services.Coupon.Commands.CreateCoupon
{
    public sealed record CreateCouponRequest
    {
        public string? Code { get; set; }
        public string? CouponDescripiton { get; set; }
        public double? DiscountValue { get; set; }
        public int? DiscountType { get; set; }
        public DateTime? CouponStartDate { get; set; }
        public DateTime? CouponEndDate { get; set; }
    }
}
