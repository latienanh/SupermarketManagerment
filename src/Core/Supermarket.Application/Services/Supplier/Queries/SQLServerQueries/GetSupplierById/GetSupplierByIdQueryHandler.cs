using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Supplier.Queries.SQLServerQueries.GetSupplierById
{
    public class GetSupplierByIdQueryHandler: IRequestHandler<GetSupplierByIdQuery,SupplierResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public GetSupplierByIdQueryHandler(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }
        public async Task<SupplierResponseDto> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _supplierRepository.GetSingleByIdAsync(request.id);
            return _mapper.Map<SupplierResponseDto>(result);
        }
    }
}
