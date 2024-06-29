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
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public string? Image { get; set; }
    public double? Price { get; set; }
    public string? Describe { get; set; }
    public Guid? ParentId { get; set; }
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