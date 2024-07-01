using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.UnitOfWork;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services
{
    public class SaleServices : ISalesService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SaleServices(IInvoiceRepository invoiceRepository, IInvoiceDetailRepository invoiceDetailRepository, IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceDetailRepository = invoiceDetailRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateInvoiceAsync(InvoiceRequestDto model, Guid userId)
        {
            model.TotalPrice = 0;
            model.InvoiceDate = DateTime.Now;
            if (!model.InvoiceDetails.IsNullOrEmpty())
            {
                foreach (var InvoiceDetail in model.InvoiceDetails)
                {
                    InvoiceDetail.TotalPrice = InvoiceDetail.Quantity * InvoiceDetail.UnitPrice;
                    model.TotalPrice += InvoiceDetail.TotalPrice;
                }
            }
            var resultMap = _mapper.Map<Invoice>(model);
            if (resultMap == null)
            {
                return false;
            }

            var resultAdd = await _invoiceRepository.AddAsync(resultMap, userId);
            if (resultAdd == null) { return false; }

            if (!model.InvoiceDetails.IsNullOrEmpty())
                foreach (var invoiceDetail in model.InvoiceDetails)
                {
                    var invoiceDetailMap = _mapper.Map<InvoiceDetail>(invoiceDetail);
                    invoiceDetailMap.InvoiceId = resultMap.Id;
                    var resultAddInvoiceDetail = await _invoiceDetailRepository.AddAsync(invoiceDetailMap, userId);
                    if (resultAddInvoiceDetail == null)
                    {
                        return false;
                    }

                    var updateQuantityProduct =
                        await _productRepository.UpdateQuantityAsyncProduct(invoiceDetailMap.Quantity, invoiceDetailMap.ProductId, userId, QuantityUpdateType.REMOVE);
                    if (updateQuantityProduct == null)
                    { return false; }
                }

            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<ICollection<InvoiceResponseDto>> GetAllStockInAsync()
        {
            var result = await _invoiceRepository.GetMultiAsync(x => x.IsDelete == false, IncludeConstants.SaleIncludes);
            var resultMap = _mapper.Map<ICollection<InvoiceResponseDto>>(result);
            return resultMap;
        }

        public async Task<SaleDateNowResponse> GetSaleDateNow()
        {
            var result = await _invoiceRepository.GetMultiAsync(x => x.IsDelete == false && x.InvoiceDate == DateTime.Today.Date);
            if (result.Count() != 0)
            {
                var response = new SaleDateNowResponse()
                {
                    totalPriceNow = (float)result.Sum(x => x.TotalPrice),
                    quantityInvoice = result.Count()
                };
                return response;
            }
            var response1 = new SaleDateNowResponse()
            {
                totalPriceNow = 0,
                quantityInvoice = 0
            };
            return response1;
        }

        public async Task<SaleDateNow1Response> GetChart()
        {
            var startDate = DateTime.Today.AddDays(-6);
            var endDate = DateTime.Today;

            var result = await _invoiceRepository.GetMultiAsync(x => x.IsDelete == false && x.InvoiceDate >= startDate && x.InvoiceDate <= endDate);

            var dailySaleData = new Dictionary<DateTime, DailySaleData>();

            // Tạo danh sách các ngày từ startDate đến endDate
            var dates = Enumerable.Range(0, 7).Select(i => startDate.AddDays(i)).ToList();

            foreach (var invoice in result)
            {
                if (invoice.InvoiceDate.HasValue)
                {
                    var invoiceDate = invoice.InvoiceDate.Value.Date;
                    if (dailySaleData.ContainsKey(invoiceDate))
                    {
                        dailySaleData[invoiceDate].TotalPrice += (float)invoice.TotalPrice;
                        dailySaleData[invoiceDate].Quantity += 1;
                    }
                    else
                    {
                        dailySaleData[invoiceDate] = new DailySaleData
                        {
                            Date = invoiceDate,
                            TotalPrice = (float)invoice.TotalPrice,
                            Quantity = 1
                        };
                    }
                }
            }

            var response = new SaleDateNow1Response
            {
                DailySaleData = dates.Select(d => dailySaleData.GetValueOrDefault(d, new DailySaleData
                {
                    Date = d,
                    TotalPrice = 0,
                    Quantity = 0
                })).ToList()
            };

            return response;
        }

        
    }
}
