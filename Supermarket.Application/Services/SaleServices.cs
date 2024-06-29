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
            if(resultAdd == null) { return false; }

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
                        await _productRepository.UpdateQuantityAsyncProduct(invoiceDetailMap.Quantity,invoiceDetailMap.ProductId, userId,QuantityUpdateType.REMOVE);
                    if (updateQuantityProduct == null)
                    { return false; }
                }

            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
