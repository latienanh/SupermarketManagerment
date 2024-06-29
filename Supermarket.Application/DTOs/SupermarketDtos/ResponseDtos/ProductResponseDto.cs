
using Supermarket.Application.DTOs.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class ProductResponseDto : BaseDTO
    {
        public string? BarCode { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Image { get; set; }
        //public Guid? ParentId { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Describe { get; set; }
        public IEnumerable<CategoryResponseDto> Categories { get; set; }

        public IEnumerable<VariantValueResponse> VariantValues { get; set; }
    }
}
