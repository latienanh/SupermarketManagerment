using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities
{
    public partial class AttributeValue : BaseDomain
    {
        public AttributeValue()
        {
            Variants = new HashSet<Variant>();
        }

        public int? AttributeId { get; set; }
        public string? AttributeValue1 { get; set; }

        public virtual Attribute? Attribute { get; set; }
        public virtual ICollection<Variant> Variants { get; set; }
    }
}
