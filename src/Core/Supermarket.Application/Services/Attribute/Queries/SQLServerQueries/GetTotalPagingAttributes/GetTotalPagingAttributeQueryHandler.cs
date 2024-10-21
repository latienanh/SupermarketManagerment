using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using System.Drawing;

namespace Supermarket.Application.Services.Attribute.Queries.SQLServerQueries.GetTotalPagingAttributes
{
    public class GetTotalPagingAttributeQueryHandler : IRequestHandler<GetTotalPagingAttributeQuery, int>
    {
        private readonly IAttributeRepository _attributeRepository;

        public GetTotalPagingAttributeQueryHandler(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }
        public async Task<int> Handle(GetTotalPagingAttributeQuery request, CancellationToken cancellationToken)
        {
            var result = await _attributeRepository.CountAsync(x => x.IsDelete == false);
            decimal total = Math.Ceiling((decimal)result / request.size);
            return (int)total;
        
        }
    }
}
