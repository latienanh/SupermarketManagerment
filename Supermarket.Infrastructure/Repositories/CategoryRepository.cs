using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMapper _mapper;
    private readonly SuperMarketDbContext _superMarketDbContext;

    public CategoryRepository(SuperMarketDbContext superMarketDbContext, IMapper mapper)
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
        var category = _mapper.Map<Category>(categoryDto);
        _superMarketDbContext.Categories.Add(category);
        _superMarketDbContext.SaveChanges();
        return category;
    }
}