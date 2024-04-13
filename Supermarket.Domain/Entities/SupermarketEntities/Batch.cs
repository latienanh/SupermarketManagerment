using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class Batch : BaseDomain
{
    public Batch()
    {
        Products = new HashSet<Product>();
    }

    public string? BatchNumber { get; set; }
    public DateTime? ManufacturingDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public int? Quantity { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}