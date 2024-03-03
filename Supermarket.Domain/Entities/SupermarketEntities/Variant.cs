using System;
using System.Collections.Generic;
using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities
{
    public partial class Variant : BaseDomain
    {
        public Variant()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
            StockInDetails = new HashSet<StockInDetail>();
            UnitConversions = new HashSet<UnitConversion>();
            Batches = new HashSet<Batch>();
        }

        public string? Title { get; set; }
        public double? BuyingPrice { get; set; }
        public double? SalePrice { get; set; }
        public int? AttributeValueId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public string? Sku { get; set; }
        public string? ImageProductVariant { get; set; }

        public virtual AttributeValue? AttributeValue { get; set; }
        public virtual Product? Product { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual ICollection<StockInDetail> StockInDetails { get; set; }
        public virtual ICollection<UnitConversion> UnitConversions { get; set; }

        public virtual ICollection<Batch> Batches { get; set; }
    }
}
