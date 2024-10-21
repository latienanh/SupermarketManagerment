using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Category.Commands.Queries.SQLServerQueries.GetTotalPagingAttributes
{
    public class GetTotalPagingCategoriesQueryHandler : IRequestHandler<GetTotalPagingCategoriesQuery,int>
    {
        private readonly IAttributeRepository _attributeRepository;

        public GetTotalPagingCategoriesQueryHandler(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }
        public async Task<int> Handle(GetTotalPagingCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _attributeRepository.CountAsync(x => x.IsDelete == false);
            decimal total = Math.Ceiling((decimal)result / request.size);
            return (int)total;
        
        }
    }
}
