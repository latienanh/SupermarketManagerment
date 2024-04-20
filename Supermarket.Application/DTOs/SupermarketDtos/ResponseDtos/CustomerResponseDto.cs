using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs.Common;
using Supermarket.Domain.Entities.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class CustomerResponseDto:BaseDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Guid? MembershipTypeId { get; set; }
    }
}
