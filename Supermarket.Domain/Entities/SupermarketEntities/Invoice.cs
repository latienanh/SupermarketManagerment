using System;
using System.Collections.Generic;
using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities
{
    public partial class Invoice : BaseDomain
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public int? CustomerId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public double? TotalPrice { get; set; }
        public int? PaymentStatus { get; set; }
        public string? PaymentMethod { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
