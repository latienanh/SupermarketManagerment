using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class Customer : BaseDomainPerson
{
    public Customer()
    {
        Invoices = new HashSet<Invoice>();
    }


    public Guid? MembershipTypeId { get; set; }

    public virtual MemberShipType? MembershipType { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
}