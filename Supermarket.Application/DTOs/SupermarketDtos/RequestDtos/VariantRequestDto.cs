using Microsoft.AspNetCore.Http;

namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos
{
    public class VariantRequestDto
    {
        public string? BarCode { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public double? Price { get; set; }
        public string? Describe { get; set; }
        public IFormFile? Image { get; set; }
        public string? PathImage { get; set; }
        public IEnumerable<VariantValueRequestDto> VariantValues { get; set; }
    }
}
