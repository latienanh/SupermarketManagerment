using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Category.Queries.SQLServerQueries.GetAllCategories
{
    internal class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryResponseDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository,
        IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
         
        }
        public async Task<IEnumerable<CategoryResponseDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAllAsync();
            var categoryMap = _mapper.Map<IEnumerable<CategoryResponseDto>>(result);
            return categoryMap;
        }
    }
}
