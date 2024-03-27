using Supermarket.Application.DTOs.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos;

public class CategoryDto : BaseDTO
{
    public int? ParentId { get; set; }
    public string? CategoryName { get; set; }
}