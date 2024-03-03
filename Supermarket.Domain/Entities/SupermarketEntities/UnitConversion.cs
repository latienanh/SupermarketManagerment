using System;
using System.Collections.Generic;
using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities
{
    public partial class UnitConversion : BaseDomain
    {
        public string? UnitName { get; set; }
        public int? Quantity { get; set; }
        public int? ProductId { get; set; }
        public int? VariantId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Variant? Variant { get; set; }
    }
}
