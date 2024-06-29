using Microsoft.AspNetCore.Identity;
using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Entities.SupermarketEntities;
using Supermarket.Domain.Entities.Token;
using Attribute = Supermarket.Domain.Entities.SupermarketEntities.Attribute;

namespace Supermarket.Domain.Entities.Identity;

public class AppUser : IdentityUser<Guid>
{
    public AppUser()
    {
        CreateAttributes = new HashSet<Attribute>();
        CreateVariantValues = new HashSet<VariantValue>();
        CreateStockIns = new HashSet<StockIn>();
        CreateSuppliers = new HashSet<Supplier>();
        CreateBatches = new HashSet<Batch>();
        CreateUnitConversions = new HashSet<UnitConversion>();
        CreateInvoices = new HashSet<Invoice>();
        CreateCustomers = new HashSet<Customer>();
        CreateProducts = new HashSet<Product>();
        CreateCategories = new HashSet<Category>();
        CreateCoupons = new HashSet<Coupon>();
        DeleteAttributes = new HashSet<Attribute>();
        DeleteVariantValues = new HashSet<VariantValue>();
        DeleteStockIns = new HashSet<StockIn>();
        DeleteSuppliers = new HashSet<Supplier>();
        DeleteBatches = new HashSet<Batch>();
        DeleteUnitConversions = new HashSet<UnitConversion>();
        DeleteInvoices = new HashSet<Invoice>();
        DeleteCustomers = new HashSet<Customer>();
        DeleteProducts = new HashSet<Product>();
        DeleteCategories = new HashSet<Category>();
        DeleteCoupons = new HashSet<Coupon>();
        CreateInvoicesDetails = new HashSet<InvoiceDetail>();
        DeleteInvoicesDetails = new HashSet<InvoiceDetail>();
        CreateMemberShipTypes = new HashSet<MemberShipType>();
        DeleteMemberShipTypes = new HashSet<MemberShipType>();
        CreateStockInsDetails = new HashSet<StockInDetail>();
        DeleteStockInsDetails = new HashSet<StockInDetail>();
        Modifications = new HashSet<Modification>();
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? FullName { get; set; }
    public string Image { get; set; }
    public ICollection<Employee> CreateEmployee { get; set; }
    public ICollection<Employee> DeleteEmployee { get; set; }
    public RefreshToken RefreshToken { get; set; }
    public ICollection<Modification> Modifications { get; }
    public ICollection<Attribute> CreateAttributes { get; }
    public ICollection<Attribute> DeleteAttributes { get; }
    public ICollection<VariantValue> CreateVariantValues { get; }
    public ICollection<VariantValue> DeleteVariantValues { get; }
    public ICollection<StockIn> CreateStockIns { get; }
    public ICollection<StockIn> DeleteStockIns { get; }
    public ICollection<Supplier> CreateSuppliers { get; }
    public ICollection<Supplier> DeleteSuppliers { get; }
    public ICollection<Batch> CreateBatches { get; }
    public ICollection<Batch> DeleteBatches { get; }
    public ICollection<UnitConversion> CreateUnitConversions { get; }
    public ICollection<UnitConversion> DeleteUnitConversions { get; }
    public ICollection<Invoice> CreateInvoices { get; }
    public ICollection<Invoice> DeleteInvoices { get; }
    public ICollection<Customer> CreateCustomers { get; }
    public ICollection<Customer> DeleteCustomers { get; }
    public ICollection<Product> CreateProducts { get; }
    public ICollection<Product> DeleteProducts { get; }
    public ICollection<Category> CreateCategories { get; }
    public ICollection<Category> DeleteCategories { get; }
    public ICollection<Coupon> CreateCoupons { get; }
    public ICollection<Coupon> DeleteCoupons { get; }
    public ICollection<InvoiceDetail> CreateInvoicesDetails { get; }
    public ICollection<InvoiceDetail> DeleteInvoicesDetails { get; }
    public ICollection<MemberShipType> CreateMemberShipTypes { get; }
    public ICollection<MemberShipType> DeleteMemberShipTypes { get; }
    public ICollection<StockInDetail> CreateStockInsDetails { get; }
    public ICollection<StockInDetail> DeleteStockInsDetails { get; }
}