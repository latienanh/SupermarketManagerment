using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Supplier.Queries.SQLServerQueries.GetTotalPagingSuppliers
{
    public class GetTotalPagingSuppliersQueryHandler : IRequestHandler<GetTotalPagingSuppliersQuery,int>
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public GetTotalPagingSuppliersQueryHandler(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }
        public async Task<int> Handle(GetTotalPagingSuppliersQuery request, CancellationToken cancellationToken)
        {
            var result = await _supplierRepository.CountAsync(x => x.IsDelete == false );
            decimal total = Math.Ceiling((decimal)result / request.size);
            return (int)total;

        }
    }
}
