using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Primitives;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class StockInDetail: Entity
{
    public Guid? ProductId { get; set; }
    public Guid? StockInId { get; set; }
    public int? QuantityReceived { get; set; }
    public double? UnitPriceReceived { get; set; }
    public double? TotalValueReceived { get; set; }

    public virtual Product? Product { get; set; }
    public virtual StockIn? StockIn { get; set; }
}