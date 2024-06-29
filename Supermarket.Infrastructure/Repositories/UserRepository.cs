using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.Auth.RequestDtos;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository<UserRequestDto,UserUpdateRequestDto, UserResponseDto>
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
        public async Task<UserResponseDto> AddAsync(UserRequestDto entity)
        {
            var entityMap = _mapper.Map<AppUser>(entity);
            entityMap.Image = entity.PathImage;
            var createResult = await _userManager.CreateAsync(entityMap, entity.Password);
            foreach (var roleId in entity.Roles)
            {
                var role = await _roleManager.FindByIdAsync(roleId.ToString());
                if (role == null)
                    continue;
                createResult = await _userManager.AddToRoleAsync(entityMap, role.Name);
            }

            if (createResult.Succeeded)
            {
                return _mapper.Map<UserResponseDto>(entityMap); ;
            }
            return null;
        }

        public async Task<UserResponseDto> UpdateAsync(UserUpdateRequestDto entity, Guid id)
        {
            var existingUser = await _userManager.FindByIdAsync(id.ToString());
            if (existingUser == null)
            {
                return null;
            }
            existingUser.Email = entity.Email;
            existingUser.PhoneNumber = entity.PhoneNumber;
            if (entity.PathImage != null)
            {
                existingUser.Image = entity.PathImage;
            }

            existingUser.FirstName = entity.FirstName;
            existingUser.LastName = entity.LastName;
            var updateResult = await _userManager.UpdateAsync(existingUser);
            if (!entity.Roles.IsNullOrEmpty())
            {
                var currentRoles = await _userManager.GetRolesAsync(existingUser); // Get current roles
                foreach (var roleId in entity.Roles)
                {
                    var role = await _roleManager.FindByIdAsync(roleId.ToString());
                    if (role == null)
                    {
                        continue; // Skip invalid roles
                    }

                    if (!currentRoles.Contains(role.Name))
                    {
                        await _userManager.AddToRoleAsync(existingUser, role.Name);
                    }
                    else
                    {
                        currentRoles.Remove(role.Name); // Remove from track of remaining roles
                    }
                }

                // Remove roles that are no longer assigned
                foreach (var roleName in currentRoles)
                {
                    await _userManager.RemoveFromRoleAsync(existingUser, roleName);
                }
            }
            // Manage roles efficiently


            if (updateResult.Succeeded)
            {
                return _mapper.Map<UserResponseDto>(existingUser);
            }

            return null;
        }

        public async Task<UserResponseDto> DeleteAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return null;
            }

            var deleteResult = await _userManager.DeleteAsync(user);

            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto> GetByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return null;
            var roleUsers = await _userManager.GetRolesAsync(user);
            var roles = new List<RoleResponseDto>();

            foreach (var roleUser in roleUsers)
            {
                var tempRole = _mapper.Map<RoleResponseDto>(await _roleManager.FindByNameAsync(roleUser));
                roles.Add(tempRole);

            }
            var userResponse = _mapper.Map<UserResponseDto>(user);
            userResponse.Roles = roles;
            if (user == null)
            {
                return null;
            }
            return userResponse;
        }

        public async Task<IEnumerable<UserResponseDto>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            var userResponses = new List<UserResponseDto>();
            foreach (var user in users)
            {
                var roleUsers = await _userManager.GetRolesAsync(user);
                var roles = new List<RoleResponseDto>();

                foreach (var roleUser in roleUsers)
                {
                    var tempRole = _mapper.Map<RoleResponseDto>(await _roleManager.FindByNameAsync(roleUser));
                    roles.Add(tempRole);

                }
                var userResponse = _mapper.Map<UserResponseDto>(user);
                userResponse.Roles = roles;
                userResponses.Add(userResponse);
            }

            if (userResponses == null)
            {
                return null;
            }
            return userResponses;
        }
    }
}
