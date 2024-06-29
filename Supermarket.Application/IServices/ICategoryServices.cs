using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.IServices;

public interface ICategoryServices : IServicesBase<CategoryRequestDto,CategoryResponseDto>
{
    Task<IEnumerable<CategoriesPagingResponseDto>> getPagingAsync(int index, int size);
    Task<int> getTotalPagingTask(int size);
}