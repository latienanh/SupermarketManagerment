using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class UnitConversion : BaseDomain
{
    public string? UnitName { get; set; }
    public int? Quantity { get; set; }
    public Guid? ProductId { get; set; }
    public virtual Product? Product { get; set; }
}