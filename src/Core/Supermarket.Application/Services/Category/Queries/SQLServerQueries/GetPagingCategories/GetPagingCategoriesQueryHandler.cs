using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using System.Drawing;

namespace Supermarket.Application.Services.Category.Queries.SQLServerQueries.GetPagingCategories
{
    public class GetPagingCategoriesQueryHandler : IRequestHandler<GetPagingCategoriesQuery, IEnumerable<CategoriesPagingResponseDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetPagingCategoriesQueryHandler(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<CategoriesPagingResponseDto>> Handle(GetPagingCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetMultiPagingAsync(x => x.IsDelete == false && x.ParentId == null, request.index, request.size);
            var resultChildren = await _categoryRepository.GetMultiPagingAsync(x => x.IsDelete == false && x.ParentId != null);
            var resultMap = _mapper.Map<IEnumerable<CategoriesPagingResponseDto>>(result);
            foreach (var categoryParent in resultMap)
            {
                var children = resultChildren.Where(x => x.ParentId == categoryParent.Id);
                if (children.Any())
                {
                    categoryParent.CategoryChildren = _mapper.Map<IEnumerable<CategoryResponseDto>>(children);
                }
            }
            return resultMap;
        }
    }
}
