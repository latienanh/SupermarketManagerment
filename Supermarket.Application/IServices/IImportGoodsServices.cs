using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.IServices
{
    public interface IImportGoodsServices
    {
        Task<bool> CreateStockInAsync(ImportGoodsRequest model,Guid userId);
        Task<bool> GetAllStockInAsync();
    }
}
