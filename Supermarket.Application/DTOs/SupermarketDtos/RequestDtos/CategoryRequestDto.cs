namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;

public class CategoryRequestDto 
{
    public Guid? ParentId { get; set; }
    public string? CategoryName { get; set; }
}