using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Inventory.Queries.SQLServerQueries.GetSaleDateNow
{
    public class GetSaleDateNowQueryHandler:IRequestHandler<GetSaleDateNowQuery,SaleDateNowResponse>
    {
        private IInvoiceRepository _invoiceRepository;

        public GetSaleDateNowQueryHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<SaleDateNowResponse> Handle(GetSaleDateNowQuery request, CancellationToken cancellationToken)
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
    }
}
