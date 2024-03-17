using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.IServices
{
    public interface ICategoryServices
    {
        List<CategoryDto> GetAllCategories();
        Category createCategory(CategoryDto categoryDto);
    }
}
