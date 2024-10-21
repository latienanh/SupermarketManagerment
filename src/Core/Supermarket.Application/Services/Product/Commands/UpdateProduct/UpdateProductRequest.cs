using Microsoft.AspNetCore.Http;
using Supermarket.Application.Common;

namespace Supermarket.Application.Services.Product.Commands.UpdateProduct
{
    public sealed record UpdateProductRequest: BaseDTORequestUpdate
    {
        public string? BarCode { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Describe { get; set; }
        public double? Price { get; set; }
        public IFormFile? Image { get; set; }
        public string? PathImage { get; set; }
        public ICollection<Guid>? CategoriesId { get; set; }
    }
}
