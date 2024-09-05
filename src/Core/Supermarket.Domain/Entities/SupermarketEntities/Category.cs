using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Primitives;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class Category :Entity
{
    public Category()
    {
        InverseParent = new HashSet<Category>();
        Products = new HashSet<Product>();
    }

    public Guid? ParentId { get; set; }
    public string? Name { get; set; }
    public string? Describe { get; set; }
    public string Image { get; set; }
    public virtual Category? Parent { get; set; }
    public virtual ICollection<Category> InverseParent { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}