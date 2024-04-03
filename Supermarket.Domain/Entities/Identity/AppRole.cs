using Microsoft.AspNetCore.Identity;
using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.Identity;

public class AppRole : IdentityRole<int>
{
    public AppRole(string name):base(name)
    {
    }
}