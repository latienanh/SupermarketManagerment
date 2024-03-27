using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.IRepositories;

public interface ICategoryRepository
{
    List<CategoryDto> getAllCategories();
    Category createCategory(CategoryDto categorydto);
}