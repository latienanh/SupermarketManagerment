
using Supermarket.Application.DTOs.Common;


namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class CategoriesPagingResponseDto:BaseDTO
    {
        public string? Name { get; set; }
        public string? Describe { get; set; }
        public string Image { get; set; }
        public IEnumerable<CategoryResponseDto>? CategoryChildren { get; set; }
    }
}
