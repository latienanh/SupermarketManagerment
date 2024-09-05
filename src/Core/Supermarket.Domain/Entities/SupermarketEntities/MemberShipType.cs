using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Primitives;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class MemberShipType : Entity
{
    public MemberShipType()
    {
        Customers = new HashSet<Customer>();
    }

    public string? Name { get; set; }

    public virtual ICollection<Customer> Customers { get; set; }
}