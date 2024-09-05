using Microsoft.AspNetCore.Http;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;

namespace Supermarket.Application.Services.User.Commands.CreateUser
{
    public sealed record CreateUserRequest
    {
        public string? UserName { get; set; }

        public string? Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile? Avatar { get; set; }
        public string? PathImage { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? PhoneNumber { get; set; }

        public IEnumerable<Guid> Roles { get; set; } = new List<Guid>();
    }
}
