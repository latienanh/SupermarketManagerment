using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Domain.Entities.Common;

public class Modification
{
    public int Id { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime ModifiedTime { get; set; }
    public string EntityType { get; set; }
    public int EntityId { get; set; }
    public AppUser AppUsers { get; set; }
}