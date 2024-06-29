using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.IServices
{
    public interface ISalesService 
    {
        Task<bool> CreateInvoiceAsync(InvoiceRequestDto model, Guid userId);
    }
}
