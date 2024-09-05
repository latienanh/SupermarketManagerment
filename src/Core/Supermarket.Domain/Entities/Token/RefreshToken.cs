using Supermarket.Domain.Entities.Identity;
using Supermarket.Domain.Primitives;

namespace Supermarket.Domain.Entities.Token;

public class RefreshToken: EntityBasic
{
    public string Token { get; set; }
    public DateTime Expriaton { get; set; }
    public Guid UserId { get; set; }
    public AppUser AppUser { get; set; }
}