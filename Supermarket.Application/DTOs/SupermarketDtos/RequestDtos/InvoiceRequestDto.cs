using Supermarket.Domain.Entities.SupermarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos
{
    public class InvoiceRequestDto
    {
        public Guid? CustomerId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public double? TotalPrice { get; set; }
        public int? PaymentStatus { get; set; }
        public string? PaymentMethod { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
