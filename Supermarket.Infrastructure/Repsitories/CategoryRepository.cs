using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Supermarket.Application.DTOs;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;
using Supermarket.Infastructure;

namespace Supermarket.Infrastructure.Repsitories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SuperMarketDbContext _superMarketDbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(SuperMarketDbContext superMarketDbContext,IMapper mapper)
        {
            _superMarketDbContext = superMarketDbContext;
            _mapper = mapper;
        }
        public List<CategoryDto> getAllCategories()
        {
            var resultList = _mapper.Map<List<CategoryDto>>(_superMarketDbContext.Categories.ToList());
            return resultList;
        }
        public Category createCategory(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);
            _superMarketDbContext.Categories.Add(category);
            _superMarketDbContext.SaveChanges();
            return category;
        }
    }
}
