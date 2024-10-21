using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Customer.Queries.SQLServerQueries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler: IRequestHandler<GetCustomerByIdQuery,CustomerResponseDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMemberShipTypeRepository _memberShipTypeRepository;
        private readonly IMapper _mapper;
        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMemberShipTypeRepository memberShipTypeRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _memberShipTypeRepository = memberShipTypeRepository;
            _mapper = mapper;
        }
        public async Task<CustomerResponseDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.GetSingleByConditionAsync(x => x.Id == request.id && x.IsDelete == false, IncludeConstants.CustomerIncludes);
            var resultMap = _mapper.Map<CustomerResponseDto>(result);
            return resultMap;
        }
    }
}
