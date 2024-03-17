
using Supermarket.Application.DTOs.Common;
using Supermarket.Domain.Entities;

namespace Supermarket.Application.DTOs.SupermarketDtos
{
    public class CategoryDto : BaseDTO
    {
        public int? ParentId { get; set; }
        public string? CategoryName { get; set; }
    }
}
