using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class StockIn : BaseDomain
{
    public StockIn()
    {
        StockInDetails = new HashSet<StockInDetail>();
    }

    public Guid? SupplierId { get; set; }
    public DateTime? EntryDate { get; set; }
    public Guid EmployeeId { get; set; }
    public double? TotalOrderValue { get; set; }
    public string? Note { get; set; }

    public virtual Supplier? Supplier { get; set; }
    public virtual Employee Employee { get; set; }
    public virtual ICollection<StockInDetail> StockInDetails { get; set; }
}