using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Infrastructure.DbFactories;

namespace Supermarket.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public RoleManager<IdentityRole<int>> _roleManager { get; set; }

        public RoleRepository(RoleManager<IdentityRole<int>> roleManager)
        {
           _roleManager=roleManager;
        }
        public async Task<IdentityRole<int>> AddAsync(IdentityRole<int> entity)
        {
            await _roleManager.CreateAsync(entity);
            return entity;
        }

        public async Task<IdentityRole<int>> UpdateAsync(IdentityRole<int> entity, int id)
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

        public async Task<IdentityRole<int>> DeleteAsync(int id)
        {
            var result = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }

            await _roleManager.DeleteAsync(result);
            return result;
        }

        public async Task<IdentityRole<int>> GetByIdAsync(int id)
        {
            var result = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<IEnumerable<IdentityRole<int>>> GetAll()
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
