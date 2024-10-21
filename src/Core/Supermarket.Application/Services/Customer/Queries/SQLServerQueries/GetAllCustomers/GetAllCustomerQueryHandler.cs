using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Customer.Queries.SQLServerQueries.GetAllCustomers
{
    internal class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerResponseDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMemberShipTypeRepository _memberShipTypeRepository;
        private readonly IMapper _mapper;
        public GetAllCustomerQueryHandler(ICustomerRepository customerRepository, IMemberShipTypeRepository memberShipTypeRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _memberShipTypeRepository = memberShipTypeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomerResponseDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.GetAllAsync();
            var resultMap = _mapper.Map<ICollection<CustomerResponseDto>>(result);
            return resultMap;
        }
    }
}
