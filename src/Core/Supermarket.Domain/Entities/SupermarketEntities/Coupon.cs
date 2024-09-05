using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Primitives;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class Coupon : Entity
{
    public Coupon()
    {
        Products = new HashSet<Product>();
    }

    public string? Code { get; set; }
    public string? CouponDescripiton { get; set; }
    public double? DiscountValue { get; set; }
    public int? DiscountType { get; set; }
    public DateTime? CouponStartDate { get; set; }
    public DateTime? CouponEndDate { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}