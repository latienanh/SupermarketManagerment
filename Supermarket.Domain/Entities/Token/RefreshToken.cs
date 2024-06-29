using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Domain.Entities.Token;

public class RefreshToken: BaseDomainBasic
{
    public string Token { get; set; }
    public DateTime Expriaton { get; set; }
    public Guid UserId { get; set; }
    public AppUser AppUser { get; set; }
}