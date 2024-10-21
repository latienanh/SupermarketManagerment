using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Supplier.Queries.SQLServerQueries.GetAllSuppliers
{
    internal class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, IEnumerable<SupplierResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public GetAllSuppliersQueryHandler(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }
        public async Task<IEnumerable<SupplierResponseDto>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var result = await _supplierRepository.GetAllAsync();
            var resultMap = _mapper.Map<IEnumerable<SupplierResponseDto>>(result);
            return resultMap;
        }
    }
}
