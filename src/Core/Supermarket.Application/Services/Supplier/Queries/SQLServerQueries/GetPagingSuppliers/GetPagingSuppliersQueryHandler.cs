using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using System.Drawing;

namespace Supermarket.Application.Services.Supplier.Queries.SQLServerQueries.GetPagingSuppliers
{
    public class GetPagingSuppliersQueryHandler : IRequestHandler<GetPagingSuppliersQuery, IEnumerable<SupplierResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public GetPagingSuppliersQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }
        public async Task<IEnumerable<SupplierResponseDto>> Handle(GetPagingSuppliersQuery request, CancellationToken cancellationToken)
        {
            var result = await _supplierRepository.GetMultiPagingAsync(x => x.IsDelete == false, request.index, request.size);
            var resultMap = _mapper.Map<IEnumerable<SupplierResponseDto>>(result);
            return resultMap;
        }
    }
}
