using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services
{
    public class ImportGoodsServices : IImportGoodsServices
    {
        private readonly IStockInRepository _stockInRepository;
        private readonly IStockInDetailRepository _stockInDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ImportGoodsServices(IStockInRepository stockInRepository,IStockInDetailRepository stockInDetailRepository,IProductRepository productRepository,IMapper mapper,IUnitOfWork unitOfWork)
        {
            _stockInRepository = stockInRepository;
            _stockInDetailRepository = stockInDetailRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateStockInAsync(ImportGoodsRequest model, Guid userId)
        {
            model.TotalOrderValue = 0;
            model.EntryDate = DateTime.Now;
            if (!model.StockInDetails.IsNullOrEmpty())
            {
                foreach (var stockInDetail in model.StockInDetails)
                {
                    stockInDetail.TotalValueReceived = stockInDetail.QuantityReceived * stockInDetail.UnitPriceReceived;
                    model.TotalOrderValue += stockInDetail.TotalValueReceived;
                }
            }
            var resultMap = _mapper.Map<StockIn>(model);
            if (resultMap == null)
            {
                return false;
            }

            var resultAdd= await _stockInRepository.AddAsync(resultMap,userId);
            if (resultAdd == null)
            { return false; }

            if (!model.StockInDetails.IsNullOrEmpty())
                foreach (var stockInDetail in model.StockInDetails)
                {
                    var stockInDetailMap = _mapper.Map<StockInDetail>(stockInDetail);
                    stockInDetailMap.StockInId = resultMap.Id;
                    var resultAddStockInDetail = await _stockInDetailRepository.AddAsync(stockInDetailMap,userId);
                    if (resultAddStockInDetail == null)
                    {
                        return false;
                    }

                    var updateQuantityProduct =
                        await _productRepository.UpdateQuantityAsyncProduct(resultAddStockInDetail.QuantityReceived,
                            stockInDetailMap.ProductId, userId,QuantityUpdateType.ADD);
                    if(updateQuantityProduct == null)
                    { return false; }
                }

            await _unitOfWork.CommitAsync();
            return  true;
        }

        public Task<bool> GetAllStockInAsync()
        {
            throw new NotImplementedException();
        }
    }
}
