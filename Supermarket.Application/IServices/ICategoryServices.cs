using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.IServices;

public interface ICategoryServices : IServicesBase<CategoryRequestDto,CategoryResponseDto>
{
    
}