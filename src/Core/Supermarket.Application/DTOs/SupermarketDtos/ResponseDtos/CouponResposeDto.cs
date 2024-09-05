using Supermarket.Application.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public sealed record CouponResposeDto :  BaseDTOResponse
    {
        public string? Code { get; set; }
        public string? CouponDescripiton { get; set; }
        public double? DiscountValue { get; set; }
        public int? DiscountType { get; set; }
        public DateTime? CouponStartDate { get; set; }
        public DateTime? CouponEndDate { get; set; }

    }
}
