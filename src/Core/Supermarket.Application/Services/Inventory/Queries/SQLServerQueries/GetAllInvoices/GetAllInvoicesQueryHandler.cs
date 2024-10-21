using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Inventory.Queries.SQLServerQueries.GetAllInvoices
{
    internal class GetAllInvoicesQueryHandler : IRequestHandler<GetAllInvoicesQuery,IEnumerable<InvoiceResponseDto>>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public GetAllInvoicesQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<InvoiceResponseDto>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
        {
            var result = await _invoiceRepository.GetMultiAsync(x => x.IsDelete == false, IncludeConstants.SaleIncludes);
            var resultMap = _mapper.Map<IEnumerable<InvoiceResponseDto>>(result);
            return resultMap;
        }
    }
}
