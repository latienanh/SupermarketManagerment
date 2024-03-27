using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.IServices;

public interface ICategoryServices
{
    List<CategoryDto> GetAllCategories();
    Category createCategory(CategoryDto categoryDto);
}