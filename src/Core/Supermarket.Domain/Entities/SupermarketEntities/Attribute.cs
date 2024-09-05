using Entity = Supermarket.Domain.Primitives.Entity;

namespace Supermarket.Domain.Entities.SupermarketEntities;
public class Attribute :Entity
{
    public Attribute()
    {
        AttributeValues = new HashSet<VariantValue>();
    }

    public string? Name { get; set; }
    public virtual ICollection<VariantValue> AttributeValues { get; set; }
}

