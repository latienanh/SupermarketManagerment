using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos
{
    public class InvoiceRequestDto
    {
        public Guid? CustomerId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public double? TotalPrice { get; set; }
        public int? PaymentStatus { get; set; }
        public string? PaymentMethod { get; set; }
        public virtual ICollection<InvoiceDetailRequest> InvoiceDetails { get; set; }
    }
}
