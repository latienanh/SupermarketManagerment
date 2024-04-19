using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.DTOs.Auth.ResponseDtos
{
    public class UserResponseDto
    {
            public Guid Id { get; set; }
            public string? UserName { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }

            //public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-10));

            //public IFormFile? Avatar { get; set; }
            public IEnumerable<RoleResponseDto> Roles { get; set; } = new List<RoleResponseDto>();
    }
}
