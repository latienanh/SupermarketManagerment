using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class MemberShipType : BaseDomain
{
    public MemberShipType()
    {
        Customers = new HashSet<Customer>();
    }

    public string? Name { get; set; }

    public virtual ICollection<Customer> Customers { get; set; }
}