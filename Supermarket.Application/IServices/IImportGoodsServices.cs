using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.IServices
{
    public interface IImportGoodsServices
    {
        Task<bool> CreateStockInAsync(ImportGoodsRequest model,Guid userId);
        Task<ICollection<StockInResponseDto>> GetAllStockInAsync();
    }
}
