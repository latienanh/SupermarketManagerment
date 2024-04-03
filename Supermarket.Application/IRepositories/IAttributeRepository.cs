using Supermarket.Application.DTOs.SupermarketDtos;
using Attribute = Supermarket.Domain.Entities.SupermarketEntities.Attribute;

namespace Supermarket.Application.IRepositories;

public interface IAttributeRepository : IEntityRepository<Attribute>
{

}