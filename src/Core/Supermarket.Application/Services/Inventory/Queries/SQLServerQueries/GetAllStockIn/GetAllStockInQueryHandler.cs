using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Inventory.Queries.SQLServerQueries.GetAllStockIn
{
    internal class GetAllStockInQueryHandler : IRequestHandler<GetAllStockInQuery, IEnumerable<StockInResponseDto>>
    {
        private readonly IStockInRepository _stockInRepository;
        private readonly IMapper _mapper;

        public GetAllStockInQueryHandler(IStockInRepository 
            stockInRepository, IMapper mapper)
        {
          
            _stockInRepository = stockInRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StockInResponseDto>> Handle(GetAllStockInQuery request, CancellationToken cancellationToken)
        {
            var result = await _stockInRepository.GetMultiAsync(x => x.IsDelete == false);
            var resultMap = _mapper.Map<IEnumerable<StockInResponseDto>>(result);
            return resultMap;
        }
    }
}
