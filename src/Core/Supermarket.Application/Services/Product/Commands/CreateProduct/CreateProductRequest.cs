using Microsoft.AspNetCore.Http;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;

namespace Supermarket.Application.Services.Product.Commands.CreateProduct
{
    public sealed record CreateProductRequest
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
