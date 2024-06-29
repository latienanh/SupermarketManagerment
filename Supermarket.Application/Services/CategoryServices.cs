using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services;

public class CategoryServices : ICategoryServices
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryServices(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _categoryRepository= categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync()
    {
        var result = await _categoryRepository.GetAllAsync();
        var resultMap = _mapper.Map<IEnumerable<CategoryResponseDto>>(result);
        return resultMap;
    }

    public async Task<CategoryResponseDto> GetByIdAsync(Guid id)
    {
        var result = await _categoryRepository.GetSingleByIdAsync(id);
        var resultMap= _mapper.Map<CategoryResponseDto>(result);
        return resultMap;
    }

    public async Task<bool> CreateAsync(CategoryRequestDto entity, Guid userID)
    {
        if (entity == null)
            return false;
        var category = _mapper.Map<Category>(entity);
        category.Image = entity.PathImage;
        var result=await _categoryRepository.AddAsync(category, userID);
        if (result == null)
            return false;
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(CategoryRequestDto entity, Guid id, Guid userID)
    {
        if (entity == null)
            return false;
        var categoryUpdate = _mapper.Map<Category>(entity);
        if (entity.PathImage != null)
        {
                categoryUpdate.Image = entity.PathImage;
        }
        var entityType = "Category";
        var result = await _categoryRepository.UpdateAsyncCategory(categoryUpdate, id, entityType, userID);
        if (result == null)
            return false;
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, Guid userID)
    {
        var result = await _categoryRepository.DeleteAsync(id, userID);
        if (result == null)
            return false;
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<IEnumerable<CategoriesPagingResponseDto>> getPagingAsync( int index, int size)
    {
        var result = await _categoryRepository.GetMultiPagingAsync(x=>x.IsDelete==false && x.ParentId == null, index,size);
        var resultChildren = await _categoryRepository.GetMultiPagingAsync(x => x.IsDelete == false && x.ParentId != null);
        var resultMap = _mapper.Map<IEnumerable<CategoriesPagingResponseDto>>(result);
        foreach (var categoryParent in resultMap )
        {
            var children = resultChildren.Where(x => x.ParentId == categoryParent.id);
            if (children.Any())
            {
                categoryParent.CategoryChildren = _mapper.Map<IEnumerable<CategoryResponseDto>>(children);
            }
        }
        return resultMap;
    }

    public async Task<int> getTotalPagingTask(int size)
    {
        var result = await _categoryRepository.CountAsync(x => x.IsDelete == false&&x.ParentId==null);
        decimal total = Math.Ceiling((decimal)result / size);
        return (int)total;
    }
}