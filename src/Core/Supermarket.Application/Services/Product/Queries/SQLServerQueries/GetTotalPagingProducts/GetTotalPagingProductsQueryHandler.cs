using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Product.Queries.SQLServerQueries.GetTotalPagingProducts
{
    public class GetTotalPagingProductsQueryHandler : IRequestHandler<GetTotalPagingProductsQuery,int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public GetTotalPagingProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(GetTotalPagingProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.CountAsync(x => x.IsDelete == false && x.ParentId == null);
            decimal total = Math.Ceiling((decimal)result / request.size);
            return (int)total;

        }
    }
}
