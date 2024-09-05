using Supermarket.Domain.Primitives;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class Customer : EntityPerson
{
    public Customer()
    {
        Invoices = new HashSet<Invoice>();
    }


    public Guid? MembershipTypeId { get; set; }

    public virtual MemberShipType? MembershipType { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
}