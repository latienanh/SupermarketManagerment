using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Domain.Entities.Common;

public class Modification
{
    public Guid Id { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime ModifiedTime { get; set; }
    public string EntityType { get; set; }
    public Guid EntityId { get; set; }
    public AppUser AppUsers { get; set; }
}