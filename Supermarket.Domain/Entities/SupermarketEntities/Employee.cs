using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class Employee : BaseDomainPerson
{
    public string? Image { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
    public virtual ICollection<StockIn> StockIns { get; set; }
}