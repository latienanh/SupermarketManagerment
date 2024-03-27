using Supermarket.Domain.Entities.SupermarketEntities;
using Attribute = Supermarket.Domain.Entities.SupermarketEntities.Attribute;

namespace Supermarket.Application.DTOs.SupermarketDtos;

public class AttributeValueDto
{
    public int? AttributeId { get; set; }
    public string? AttributeValue1 { get; set; }

}