using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Category.Commands.Queries.SQLServerQueries.GetAllAttributes
{
    internal class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<AttributeResponseDto>>
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IAttributeRepository attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AttributeResponseDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _attributeRepository.GetAllAsync();
            var productMap = _mapper.Map<IEnumerable<AttributeResponseDto>>(result);
            return productMap;
        }
    }
}
