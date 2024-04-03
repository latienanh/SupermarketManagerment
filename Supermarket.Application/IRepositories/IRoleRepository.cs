using Microsoft.AspNetCore.Identity;

namespace Supermarket.Application.IRepositories
{
    public interface IRoleRepository : IBasicRepository<IdentityRole<int>>
    {
    }
}
