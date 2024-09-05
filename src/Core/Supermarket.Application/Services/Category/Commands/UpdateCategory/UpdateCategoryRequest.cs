using Microsoft.AspNetCore.Http;
using Supermarket.Application.Common;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;

namespace Supermarket.Application.Services.Category.Commands.UpdateCategory
{
    public sealed record UpdateCategoryRequest : BaseDTORequestUpdate
    {
        public Guid? ParentId { get; set; }
        public string? Name { get; set; }
        public string? Describe { get; set; }
        public IFormFile? Image { get; set; }
        public string? PathImage { get; set; }
    }
}
