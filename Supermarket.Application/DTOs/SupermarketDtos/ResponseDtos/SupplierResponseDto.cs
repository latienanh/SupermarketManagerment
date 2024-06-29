using Supermarket.Application.DTOs.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class SupplierResponseDto :BaseDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
