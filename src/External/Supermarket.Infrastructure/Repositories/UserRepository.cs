using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository<AppUser>
    {
        public UserManager<AppUser> _userManager;
        public RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<AppUser> userManager, IMapper mapper, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public async Task<AppUser> AddAsync(AppUser entity)
        {
            var createResult = await _userManager.CreateAsync(entity,entity.PasswordHash);
            if (createResult.Succeeded)
            {
                return entity;
            }
            return null;
        }

        public async Task<AppUser> UpdateAsync(AppUser entity)
        {
            var existingUser = await _userManager.FindByIdAsync(entity.Id.ToString());
            if (existingUser == null)
            {
                return null;
            }
            existingUser.Email = entity.Email;
            existingUser.PhoneNumber = entity.PhoneNumber;
            existingUser.Image = entity.Image;
            existingUser.FirstName = entity.FirstName;
            existingUser.LastName = entity.LastName;
            var updateResult = await _userManager.UpdateAsync(existingUser);
            if (updateResult.Succeeded)
            {
                return existingUser;
            }

            return null;
        }

        public async Task<AppUser> DeleteAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return null;
            }

            var deleteResult = await _userManager.DeleteAsync(user);

            if (deleteResult.Succeeded)
            {
                return user;
            }
            return null!;
        }

        public async Task<AppUser> GetByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return null;
            return user;

        }
        public async Task<List<IdentityRole<Guid>>> GetRolesByUserAsync(AppUser user)
        {
            var roleUsers = await _userManager.GetRolesAsync(user);
            var roles = new List<IdentityRole<Guid>>();

            foreach (var roleUser in roleUsers)
            {
                var tempRole = await _roleManager.FindByNameAsync(roleUser);
                roles.Add(tempRole);
            }
            return roles;

        }
        //public Task<bool> AddRoleInUser(IEnumerable<Guid> Roles, ref AppUser entity)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> AddRoleInUser(IEnumerable<Guid> Roles, AppUser entity)
        {
            foreach (var roleId in Roles)
            {
                var role = await _roleManager.FindByIdAsync(roleId.ToString());
                if (role == null)
                    continue;
                var createResult = await _userManager.AddToRoleAsync(entity, role.Name);
                if (!createResult.Succeeded)
                    return false;
            }

            return true;
        }

        public async Task<bool> UpdateRoleInUser(IEnumerable<Guid> Roles, AppUser entity)
        {
            if (!Roles.IsNullOrEmpty())
            {
                var currentRoles = await _userManager.GetRolesAsync(entity); // Get current roles
                foreach (var roleId in Roles)
                {
                    var role = await _roleManager.FindByIdAsync(roleId.ToString());
                    if (role == null)
                    {
                        continue; // Skip invalid roles
                    }

                    if (!currentRoles.Contains(role.Name))
                    {
                        await _userManager.AddToRoleAsync(entity, role.Name);
                    }
                    else
                    {
                        currentRoles.Remove(role.Name); // Remove from track of remaining roles
                    }
                }

                // Remove roles that are no longer assigned
                foreach (var roleName in currentRoles)
                {
                    await _userManager.RemoveFromRoleAsync(entity, roleName);
                }
            }

            return true;
        }

        public async Task<IEnumerable<AppUser>> GetMultiPagingAsync(int size, int index)
        {
            var users = await _userManager.Users.Skip(size*index).Take(size).ToListAsync();
            return users;
        }

        public async Task<int> GetTotalPagingAsync(int size)
        {
            var users = await _userManager.Users.ToListAsync();
            var total = Math.Ceiling((decimal)(users.Count() / size)) ;
            return (int)total;
        }


        public async Task<IEnumerable<AppUser>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }
    }
}
