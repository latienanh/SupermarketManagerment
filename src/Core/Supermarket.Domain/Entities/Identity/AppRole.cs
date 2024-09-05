using Microsoft.AspNetCore.Identity;

namespace Supermarket.Domain.Entities.Identity;

public class AppRole : IdentityRole<Guid>
{
    public AppRole(string name):base(name)
    {
    }
}