using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class Supplier : BaseDomain
{
    public Supplier()
    {
        StockIns = new HashSet<StockIn>();
    }

    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

    public virtual ICollection<StockIn> StockIns { get; set; }
}