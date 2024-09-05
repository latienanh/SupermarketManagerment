using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Primitives;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class VariantValue : Entity
{
    public Guid? AttributeId { get; set; }
    public Guid? ProductId { get; set; }
    public string? AttributeValueName { get; set; }

    public virtual Attribute? Attribute { get; set; }
    public virtual Product? Product { get; set; }
}