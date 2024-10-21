using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Attribute.Queries.SQLServerQueries.GetPagingAttributes
{
    public class GetPagingAttributeQueryHandler : IRequestHandler<GetPagingAttributeQuery, IEnumerable<AttributeResponseDto>>
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;

        public GetPagingAttributeQueryHandler(IAttributeRepository attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AttributeResponseDto>> Handle(GetPagingAttributeQuery request, CancellationToken cancellationToken)
        {
            var result =
                await _attributeRepository.GetMultiPagingAsync(x => x.IsDelete == false, request.index, request.size);
            var resultMap = _mapper.Map<IEnumerable<AttributeResponseDto>>(result);
            return resultMap;
        }
    }
}
