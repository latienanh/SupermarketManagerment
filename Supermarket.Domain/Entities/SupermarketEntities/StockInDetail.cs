using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class StockInDetail: BaseDomain
{
    public Guid? ProductId { get; set; }
    public Guid? StockInId { get; set; }
    public double? Price { get; set; }
    public int? QuantityReceived { get; set; }
    public double? UnitPriceReceived { get; set; }
    public double? TotalValueReceived { get; set; }

    public virtual Product? Product { get; set; }
    public virtual StockIn? StockIn { get; set; }
}