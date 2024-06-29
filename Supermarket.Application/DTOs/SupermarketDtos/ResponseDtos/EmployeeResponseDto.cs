using Supermarket.Application.DTOs.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class EmployeeResponseDto :BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}
