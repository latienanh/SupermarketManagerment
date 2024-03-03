using System;
using System.Collections.Generic;
using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities
{
    public partial class StockIn : BaseDomain
    {
        public StockIn()
        {
            StockInDetails = new HashSet<StockInDetail>();
        }

        public int? SupplierId { get; set; }
        public DateTime? EntryDate { get; set; }
        public double? TotalOrderValue { get; set; }
        public string? Note { get; set; }
      

        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<StockInDetail> StockInDetails { get; set; }
    }
}
