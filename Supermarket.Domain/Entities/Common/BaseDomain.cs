using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Domain.Entities.Common;

public class BaseDomain
{
    public int Id { get; set; }
    public bool? IsDelete { get; set; }
    public int? CreateBy { get; set; }
    public DateTime CreateTime { get; set; }
    public int? DeleteBy { get; set; }
    public AppUser UserCreate { get; set; }
    public AppUser UserDelete { get; set; }
}