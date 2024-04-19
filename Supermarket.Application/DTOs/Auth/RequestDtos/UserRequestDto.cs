using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.DTOs.Auth.RequestDtos
{
    public class UserRequestDto
    {
        public string? UserName { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }


        public string? PhoneNumber { get; set; }

        //public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-10));

        //public IFormFile? Avatar { get; set; }
        public IEnumerable<Guid> Roles { get; set; } = new List<Guid>();
    }
}
