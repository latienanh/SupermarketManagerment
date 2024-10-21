using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Attribute.Queries.SQLServerQueries.GetAttributeById
{
    public class GetAttributeByIdQueryHandler : IRequestHandler<GetAttributeByIdQuery, AttributeResponseDto>
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;

        public GetAttributeByIdQueryHandler(IAttributeRepository attributeRepository,IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }
        public async Task<AttributeResponseDto> Handle(GetAttributeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _attributeRepository.GetSingleByIdAsync(request.id);
            return _mapper.Map<AttributeResponseDto>(result);
        }
    }
}
