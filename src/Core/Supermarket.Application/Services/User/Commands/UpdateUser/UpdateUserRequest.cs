using Microsoft.AspNetCore.Http;
using Supermarket.Application.Common;

namespace Supermarket.Application.Services.User.Commands.UpdateUser
{
    public sealed record UpdateUserRequest : BaseDTORequestUpdate
    {
        public string? Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile? Avatar { get; set; }
        public string? PathImage { get; set; }
        public string? PhoneNumber { get; set; }
        public IEnumerable<Guid>? Roles { get; set; } = new List<Guid>();
    }
}
