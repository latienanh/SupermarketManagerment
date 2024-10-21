using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services.Inventory.Commands.ImportGoods
{
    public sealed class ImportGoodsCommandHandler : ICommandHandler<ImportGoodsCommand, Guid?>
    {
        private readonly IStockInRepository _stockInRepository;
        private readonly IStockInDetailRepository _stockInDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ImportGoodsCommandHandler(IStockInRepository stockInRepository, IStockInDetailRepository stockInDetailRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _stockInRepository = stockInRepository;
            _stockInDetailRepository = stockInDetailRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid?> Handle(ImportGoodsCommand model, CancellationToken cancellationToken)
        {
            model.ImportGoodsRequest.TotalOrderValue = 0;
            model.ImportGoodsRequest.EntryDate = DateTime.Now;
            if (!model.ImportGoodsRequest.StockInDetails.IsNullOrEmpty())
            {
                foreach (var stockInDetail in model.ImportGoodsRequest.StockInDetails)
                {
                    stockInDetail.TotalValueReceived = stockInDetail.QuantityReceived * stockInDetail.UnitPriceReceived;
                    model.ImportGoodsRequest.TotalOrderValue += stockInDetail.TotalValueReceived;
                }
            }
            var resultMap = _mapper.Map<StockIn>(model.ImportGoodsRequest);
            if (resultMap == null)
            {
                return null;
            }

            var resultAdd = await _stockInRepository.AddAsync(resultMap, model.userId);
            if (resultAdd == null)
            { return null; }

            if (!model.ImportGoodsRequest.StockInDetails.IsNullOrEmpty())
                foreach (var stockInDetail in model.ImportGoodsRequest.StockInDetails)
                {
                    var stockInDetailMap = _mapper.Map<StockInDetail>(stockInDetail);
                    stockInDetailMap.StockInId = resultMap.Id;
                    var resultAddStockInDetail = await _stockInDetailRepository.AddAsync(stockInDetailMap, model.userId);
                    if (resultAddStockInDetail == null)
                    {
                        return null;
                    }

                    var updateQuantityProduct =
                        await _productRepository.UpdateQuantityAsyncProduct(resultAddStockInDetail.QuantityReceived,
                            stockInDetailMap.ProductId, model.userId, QuantityUpdateType.ADD);
                    if (updateQuantityProduct == null)
                    { return null; }
                }

            await _unitOfWork.CommitAsync(cancellationToken);
            return resultAdd.Id;
        }



    }
}
