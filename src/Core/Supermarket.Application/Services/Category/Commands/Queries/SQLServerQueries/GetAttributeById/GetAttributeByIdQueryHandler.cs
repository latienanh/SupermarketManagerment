using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Category.Commands.Queries.SQLServerQueries.GetAttributeById
{
    public class GetCategoryByIdQueryHandler: IRequestHandler<GetCategoryByIdQuery,AttributeResponseDto>
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IAttributeRepository attributeRepository,IMapper mapper)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
        }
        public async Task<AttributeResponseDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _attributeRepository.GetSingleByIdAsync(request.id);
            return _mapper.Map<AttributeResponseDto>(result);
        }
    }
}
