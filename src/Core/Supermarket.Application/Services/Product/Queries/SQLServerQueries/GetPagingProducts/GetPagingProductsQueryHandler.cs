using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using System.Drawing;

namespace Supermarket.Application.Services.Product.Queries.SQLServerQueries.GetPagingProducts
{
    public class GetPagingProductsQueryHandler : IRequestHandler<GetPagingProductsQuery, IEnumerable<ProductsPagingResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public GetPagingProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductsPagingResponseDto>> Handle(GetPagingProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetMultiPagingAsync(x => x.IsDelete == false && x.ParentId == null, request.index, request.size, IncludeConstants.ProductIncludes);
            var resultChildren = await _productRepository.GetMultiAsync(x => x.IsDelete == false && x.ParentId != null, IncludeConstants.ProductIncludes);
            var resultMap = _mapper.Map<IEnumerable<ProductsPagingResponseDto>>(result);
            foreach (var productParent in resultMap)
            {
                var children = resultChildren.Where(x => x.ParentId == productParent.Id);
                if (children.Any())
                {
                    productParent.Variants = _mapper.Map<IEnumerable<ProductResponseDto>>(children);
                }
            }
            return resultMap;
        }
    }
}
