using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Primitives;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class UnitConversion : Entity
{
    public string? UnitName { get; set; }
    public int? Quantity { get; set; }
    public Guid? ProductId { get; set; }
    public virtual Product? Product { get; set; }
}