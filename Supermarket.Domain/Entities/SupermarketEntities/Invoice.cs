using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class Invoice : BaseDomain
{
    public Invoice()
    {
        InvoiceDetails = new HashSet<InvoiceDetail>();
    }

    public Guid? CustomerId { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public Guid EmployeeId { get; set; }
    public double? TotalPrice { get; set; }
    public int? PaymentStatus { get; set; }
    public string? PaymentMethod { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
}