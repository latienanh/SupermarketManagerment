using Supermarket.Domain.Entities.SupermarketEntities;
using Supermarket.Application.DTOs.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class InvoiceResponseDto:BaseDTO

    {
    public Guid? CustomerId { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public double? TotalPrice { get; set; }
    public int? PaymentStatus { get; set; }
    public string? PaymentMethod { get; set; }
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
