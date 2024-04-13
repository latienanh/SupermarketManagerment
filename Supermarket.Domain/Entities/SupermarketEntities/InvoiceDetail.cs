using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class InvoiceDetail : BaseDomain
{
    public int ProductId { get; set; }
    public int? VariantId { get; set; }
    public int InvoiceId { get; set; }
    public int? Quantity { get; set; }
    public double? UnitPrice { get; set; }
    public double? TotalPrice { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}