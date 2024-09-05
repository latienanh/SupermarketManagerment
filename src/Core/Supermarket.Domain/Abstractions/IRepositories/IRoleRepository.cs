using Microsoft.AspNetCore.Identity;

namespace Supermarket.Domain.Abstractions.IRepositories
{
    public  interface IRoleRepository : IBasicRepository<IdentityRole<Guid>>
    {
    }
}
