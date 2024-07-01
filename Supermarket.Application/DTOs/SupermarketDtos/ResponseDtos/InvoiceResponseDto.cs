using Supermarket.Domain.Entities.SupermarketEntities;
using Supermarket.Application.DTOs.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class InvoiceResponseDto:BaseDTO

    {
        public Guid? CustomerId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public double? TotalPrice { get; set; }
        public int? PaymentStatus { get; set; }
        public string? PaymentMethod { get; set; }
        public CustomerResponseDto? Customer { get; set; }
        public EmployeeResponseDto Employee { get; set; }
        public  ICollection<InvoiceDetailResponseDto> InvoiceDetails { get; set; }
    }
}
