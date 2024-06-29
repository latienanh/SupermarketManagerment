using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.DTOs.Auth.ResponseDtos
{
    public class UserResponseDto
    {
            public Guid Id { get; set; }
            public string? UserName { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string? FullName { get; set; }
            public string Image { get; set; }

        //public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-10));

        //public IFormFile? Avatar { get; set; }
        public IEnumerable<RoleResponseDto> Roles { get; set; } = new List<RoleResponseDto>();
    }
}
