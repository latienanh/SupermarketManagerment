using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using System.Drawing;

namespace Supermarket.Application.Services.Customer.Queries.SQLServerQueries.GetPagingCustomers
{
    public class GetPagingCustomersQueryHandler : IRequestHandler<GetPagingCustomersQuery, IEnumerable<CustomerResponseDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetPagingCustomersQueryHandler(ICustomerRepository customerRepository, IMemberShipTypeRepository memberShipTypeRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomerResponseDto>> Handle(GetPagingCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.GetMultiPagingAsync(x => x.IsDelete == false, request.index, request.size, IncludeConstants.CustomerIncludes);
            var resultMap = _mapper.Map<IEnumerable<CustomerResponseDto>>(result);
            return resultMap;
        }
    }
}
