using System;
using System.Collections.Generic;

namespace Supermarket.Domain.Entities.SupermarketEntities
{
    public partial class StockInDetail
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? VariantId { get; set; }
        public int? StockInId { get; set; }
        public double? Price { get; set; }
        public int? QuantityReceived { get; set; }
        public double? UnitPriceReceived { get; set; }
        public double? TotalValueReceived { get; set; }

        public virtual Product? Product { get; set; }
        public virtual StockIn? StockIn { get; set; }
        public virtual Variant? Variant { get; set; }
    }
}
