using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.IRepositories
{
    public interface ICategoryRepository
    {
        List<CategoryDto> getAllCategories();
        Category createCategory(CategoryDto categorydto);
    }
}
