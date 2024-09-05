using Supermarket.Domain.Primitives;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class Employee : EntityPerson
{
    public string? Image { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
    public virtual ICollection<StockIn> StockIns { get; set; }
}