using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.IServices
{
    public interface IProductServices : IServicesBase<ProductRequestDto, ProductResponseDto>
    {
        Task<IEnumerable<ProductsPagingResponseDto>> getPagingAsync(int index, int size);
        Task<int> getTotalPagingTask(int size);
    }
}
