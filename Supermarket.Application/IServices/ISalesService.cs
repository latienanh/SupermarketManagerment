using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;

namespace Supermarket.Application.IServices
{
    public interface ISalesService 
    {
        Task<bool> CreateInvoiceAsync(InvoiceRequestDto model, Guid userId);
        Task<ICollection<InvoiceResponseDto>> GetAllStockInAsync();
        Task<SaleDateNowResponse> GetSaleDateNow();
        Task<SaleDateNow1Response> GetChart();
    }
}
