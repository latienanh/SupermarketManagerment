using Supermarket.Domain.Entities.SupermarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos
{
    public class VariantRequestDto
    {
        public string? Title { get; set; }
        public double? BuyingPrice { get; set; }
        public double? SalePrice { get; set; }
        public int? AttributeValueId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public string? Sku { get; set; }
        public string? ImageProductVariant { get; set; }

        public virtual VariantValue? AttributeValue { get; set; }
        public virtual Product? Product { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual ICollection<StockInDetail> StockInDetails { get; set; }
        public virtual ICollection<UnitConversion> UnitConversions { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }
    }
}
