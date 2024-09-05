using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Primitives;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class Supplier : Entity
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