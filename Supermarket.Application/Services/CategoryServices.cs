using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryDto> GetAllCategories()
        {
            return _categoryRepository.getAllCategories();
        }

        public Category createCategory(CategoryDto categoryDto)
        {
            return _categoryRepository.createCategory(categoryDto);
        }
    }
}
