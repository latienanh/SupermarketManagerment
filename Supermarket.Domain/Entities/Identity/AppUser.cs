using Microsoft.AspNetCore.Identity;
using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Entities.SupermarketEntities;
using Supermarket.Domain.Entities.Token;
using Attribute = Supermarket.Domain.Entities.SupermarketEntities.Attribute;

namespace Supermarket.Domain.Entities.Identity;

public class AppUser : IdentityUser<int>
{
    public AppUser()
    {
        Attributes = new HashSet<Attribute>();
        AttributeValues = new HashSet<AttributeValue>();
        StockIns = new HashSet<StockIn>();
        Suppliers = new HashSet<Supplier>();
        Variants = new HashSet<Variant>();
        Batches = new HashSet<Batch>();
        UnitConversions = new HashSet<UnitConversion>();
        Invoices = new HashSet<Invoice>();
        Customers = new HashSet<Customer>();
        Products = new HashSet<Product>();
        Categories = new HashSet<Category>();
        Coupons = new HashSet<Coupon>();
        Modifications = new HashSet<Modification>();
    }

    public Employee Employee { get; set; } = null!;
    public RefreshToken RefreshToken { get; set; }
    public ICollection<Modification> Modifications { get; }
    public ICollection<Attribute> Attributes { get; }
    public ICollection<AttributeValue> AttributeValues { get; }
    public ICollection<StockIn> StockIns { get; }
    public ICollection<Supplier> Suppliers { get; }
    public ICollection<Variant> Variants { get; }
    public ICollection<Batch> Batches { get; }
    public ICollection<UnitConversion> UnitConversions { get; }
    public ICollection<Invoice> Invoices { get; }
    public ICollection<Customer> Customers { get; }
    public ICollection<Product> Products { get; }
    public ICollection<Category> Categories { get; }
    public ICollection<Coupon> Coupons { get; }
}