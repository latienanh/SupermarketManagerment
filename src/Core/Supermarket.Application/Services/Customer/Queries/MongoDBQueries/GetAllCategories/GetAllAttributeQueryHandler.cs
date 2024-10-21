using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Customer.Queries.MongoDBQueries.GetAllCategories
{
    internal class GetAllAttributeQueryHandler : IRequestHandler<GetAllAttributeQuery, IEnumerable<AttributeResponseDto>>
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;

        public GetAllAttributeQueryHandler(IAttributeRepository attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AttributeResponseDto>> Handle(GetAllAttributeQuery request, CancellationToken cancellationToken)
        {
            var result = await _attributeRepository.GetAllAsync();
            var productMap = _mapper.Map<IEnumerable<AttributeResponseDto>>(result);
            return productMap;
        }
    }
}
