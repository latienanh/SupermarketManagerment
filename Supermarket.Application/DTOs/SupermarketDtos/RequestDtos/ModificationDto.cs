namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;

public class ModificationDto
{
    public int? ModifiedBy { get; set; }
    public DateTime ModifiedTime { get; set; }
    public string EntityType { get; set; }
    public int EntityId { get; set; }
}