using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Inventory.Queries.SQLServerQueries.GetChartSale
{
    public class GetChartSaleQueryHandler: IRequestHandler<GetChartSaleQuery,SaleDateNow1Response>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public GetChartSaleQueryHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public async Task<SaleDateNow1Response> Handle(GetChartSaleQuery request, CancellationToken cancellationToken)
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
