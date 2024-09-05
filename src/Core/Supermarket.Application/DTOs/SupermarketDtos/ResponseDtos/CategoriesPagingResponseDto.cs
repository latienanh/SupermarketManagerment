
using Supermarket.Application.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public sealed record CategoriesPagingResponseDto:BaseDTOResponse
    {
        public string? Name { get; set; }
        public string? Describe { get; set; }
        public string Image { get; set; }
        public IEnumerable<CategoryResponseDto>? CategoryChildren { get; set; }
    }
}
