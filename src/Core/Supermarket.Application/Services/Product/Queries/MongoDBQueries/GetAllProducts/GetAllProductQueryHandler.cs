using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Product.Queries.MongoDBQueries.GetAllProducts
{
    internal class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<AttributeResponseDto>>
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IAttributeRepository attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AttributeResponseDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _attributeRepository.GetAllAsync();
            var productMap = _mapper.Map<IEnumerable<AttributeResponseDto>>(result);
            return productMap;
        }
    }
}
