using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Product.Queries.SQLServerQueries.GeProductById
{
    public class GetProductByIdQueryHandler: IRequestHandler<GetProductByIdQuery,ProductResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductResponseDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetSingleByConditionAsync((product) => product.Id == request.id,
                IncludeConstants.ProductIncludes);
            var resultMap = _mapper.Map<ProductResponseDto>(result);
            return resultMap;
        }
    }
}
