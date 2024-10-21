using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Services.Inventory.Commands.Sale
{
    internal class SaleCommandHandler : IRequestHandler<SaleCommand,Guid?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly IInvoiceRepository _invoiceRepository;

        public SaleCommandHandler(IMapper mapper,IUnitOfWork unitOfWork,IProductRepository productRepository,IInvoiceDetailRepository invoiceDetailRepository,IInvoiceRepository invoiceRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _invoiceDetailRepository = invoiceDetailRepository;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Guid?> Handle(SaleCommand request, CancellationToken cancellationToken)
        {
            request.InvoiceRequest.TotalPrice = 0;
            request.InvoiceRequest.InvoiceDate = DateTime.Now;
            if (!request.InvoiceRequest.InvoiceDetails.IsNullOrEmpty())
            {
                foreach (var InvoiceDetail in request.InvoiceRequest.InvoiceDetails)
                {
                    InvoiceDetail.TotalPrice = InvoiceDetail.Quantity * InvoiceDetail.UnitPrice;
                    request.InvoiceRequest.TotalPrice += InvoiceDetail.TotalPrice;
                }
            }
            var resultMap = _mapper.Map<Invoice>(request.InvoiceRequest);
            if (resultMap == null)
            {
                return null;
            }

            var resultAdd = await _invoiceRepository.AddAsync(resultMap, request.UserId);
            if (resultAdd == null) { return null; }

            if (!request.InvoiceRequest.InvoiceDetails.IsNullOrEmpty())
                foreach (var invoiceDetail in request.InvoiceRequest.InvoiceDetails)
                {
                    var invoiceDetailMap = _mapper.Map<InvoiceDetail>(invoiceDetail);
                    invoiceDetailMap.InvoiceId = resultMap.Id;
                    var resultAddInvoiceDetail = await _invoiceDetailRepository.AddAsync(invoiceDetailMap, request.UserId);
                    if (resultAddInvoiceDetail == null)
                    {
                        return null;
                    }

                    var updateQuantityProduct =
                        await _productRepository.UpdateQuantityAsyncProduct(invoiceDetailMap.Quantity, invoiceDetailMap.ProductId, request.UserId, QuantityUpdateType.REMOVE);
                    if (updateQuantityProduct == null)
                    { return null; }
                }

            await _unitOfWork.CommitAsync(cancellationToken);
            return resultAdd.Id;
        }
    }
}
