using Microsoft.AspNetCore.Http;

namespace Supermarket.Application.DTOs.Auth.RequestDtos
{
    public class SignUpRequestDto
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
            //public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-10));

    }
}
