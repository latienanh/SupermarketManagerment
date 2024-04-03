namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;

public class CategoryRequestDto 
{
    public int? ParentId { get; set; }
    public string? CategoryName { get; set; }
}