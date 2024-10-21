using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;
using System.Drawing;

namespace Supermarket.Application.Services.Category.Queries.SQLServerQueries.GetTotalPagingCategories
{
    public class GetTotalPagingCategoriesQueryHandler : IRequestHandler<GetTotalPagingCategoriesQuery,int>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetTotalPagingCategoriesQueryHandler(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;

        }
        public async Task<int> Handle(GetTotalPagingCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.CountAsync(x => x.IsDelete == false && x.ParentId == null);
            decimal total = Math.Ceiling((decimal)result / request.size);
            return (int)total;

        }
    }
}
