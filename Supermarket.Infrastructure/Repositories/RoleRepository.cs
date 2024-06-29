using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.IRepositories;

namespace Supermarket.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public RoleManager<IdentityRole<Guid>> _roleManager { get; set; }

        public RoleRepository(RoleManager<IdentityRole<Guid>> roleManager)
        {
           _roleManager=roleManager;
        }
        public async Task<IdentityRole<Guid>> AddAsync(IdentityRole<Guid> entity)
        {
            await _roleManager.CreateAsync(entity);
            return entity;
        }

        public async Task<IdentityRole<Guid>> UpdateAsync(IdentityRole<Guid> entity, Guid id)
        {
            var result = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            result.Name = entity.Name;
            await _roleManager.UpdateAsync(result);
            return entity;
        }

        public async Task<IdentityRole<Guid>> DeleteAsync(Guid id)
        {
            var result = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }

            await _roleManager.DeleteAsync(result);
            return result;
        }

        public async Task<IdentityRole<Guid>> GetByIdAsync(Guid id)
        {
            var result = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<IEnumerable<IdentityRole<Guid>>> GetAll()
        {
            var result = _roleManager.Roles.AsEnumerable();
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}
