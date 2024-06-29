using Microsoft.AspNetCore.Http;

namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;

public class CategoryRequestDto 
{
    public Guid? ParentId { get; set; }
    public string? Name { get; set; }
    public string? Describe { get; set; }
    public IFormFile? Image { get; set; }
    public string? PathImage { get; set; }
}