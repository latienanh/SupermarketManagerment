using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Domain.Entities.Common;

public class BaseDomain
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool? IsDelete { get; set; }
    public Guid? CreateBy { get; set; }
    public DateTime CreateTime { get; set; }
    public Guid? DeleteBy { get; set; }
    public AppUser UserCreate { get; set; }
    public AppUser UserDelete { get; set; }
}