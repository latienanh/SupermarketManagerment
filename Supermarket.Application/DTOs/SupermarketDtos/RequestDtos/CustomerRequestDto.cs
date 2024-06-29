﻿namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos
{
    public class CustomerRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid MembershipTypeId { get; set; }
    }
}
