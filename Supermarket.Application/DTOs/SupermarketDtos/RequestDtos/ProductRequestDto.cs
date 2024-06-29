using Microsoft.AspNetCore.Http;

namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos
{
    public class ProductRequestDto
    {
        public string? BarCode { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Describe { get; set; }
        public double? Price { get; set; }
        public IFormFile? Image { get; set; }
        public string? PathImage { get; set; }
        public ICollection<Guid>? CategoriesId { get; set; }
        public ICollection<VariantRequestDto>? Variants { get; set; } 
    }
}
