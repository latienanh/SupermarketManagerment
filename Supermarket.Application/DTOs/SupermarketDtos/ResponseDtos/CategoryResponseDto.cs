using Supermarket.Application.DTOs.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class CategoryResponseDto:BaseDTO
    {
        public Guid? ParentId { get; set; }
        public string? Name { get; set; }
        public string? Describe { get; set; }
        public string Image { get; set; }
    }
}
