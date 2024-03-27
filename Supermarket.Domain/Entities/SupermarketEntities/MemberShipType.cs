namespace Supermarket.Domain.Entities.SupermarketEntities;

public class MemberShipType
{
    public MemberShipType()
    {
        Customers = new HashSet<Customer>();
    }

    public int Id { get; set; }
    public string? Name { get; set; }

    public virtual ICollection<Customer> Customers { get; set; }
}