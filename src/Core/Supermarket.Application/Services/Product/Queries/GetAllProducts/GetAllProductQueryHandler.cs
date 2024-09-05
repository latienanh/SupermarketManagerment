using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Product.Queries.GetAllProducts
{
    internal class GetAllAttributeQueryHandler : IRequestHandler<GetAllAttributeQuery,IEnumerable<ProductResponseDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllAttributeQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductResponseDto>> Handle(GetAllAttributeQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetAllAsync();
            var productMap = _mapper.Map<IEnumerable<ProductResponseDto>>(result);
            return productMap;
        }
    }
}
