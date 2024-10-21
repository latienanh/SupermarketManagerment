using Microsoft.AspNetCore.Http;
using Supermarket.Application.Common;

namespace Supermarket.Application.Services.Category.Commands.UpdateCategory
{
    public sealed record UpdateCategoryRequest : BaseDTORequestUpdate
    {
        public string? Name { get; set; }
        public string? Describe { get; set; }
        public IFormFile? Image { get; set; }
        public string? PathImage { get; set; }
    }
}
