using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class Product : BaseDomain
{
    public Product()
    {
        InvoiceDetails = new HashSet<InvoiceDetail>();
        StockInDetails = new HashSet<StockInDetail>();
        UnitConversions = new HashSet<UnitConversion>();
        VariantValues = new HashSet<VariantValue>();
        Batches = new HashSet<Batch>();
        Categories = new HashSet<Category>();
        Coupons = new HashSet<Coupon>();
    }

    public string? BarCode { get; set; }
    public string? ProductName { get; set; }
    public string? ProductSlug { get; set; }
    public string? ProductImage { get; set; }
    public int? ParentId { get; set; }
    public int? Quantity { get; set; }
    public virtual Product? Parent { get; set; }
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    public virtual ICollection<StockInDetail> StockInDetails { get; set; }
    public virtual ICollection<UnitConversion> UnitConversions { get; set; }
    public virtual ICollection<VariantValue> VariantValues { get; set; }
    public virtual ICollection<Product> InverseParent { get; set; }
    public virtual ICollection<Batch> Batches { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Coupon> Coupons { get; set; }
}