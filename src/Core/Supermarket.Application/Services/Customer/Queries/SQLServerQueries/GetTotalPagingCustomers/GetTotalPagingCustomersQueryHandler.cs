using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Customer.Queries.SQLServerQueries.GetTotalPagingCustomers
{
    public class GetTotalPagingCustomersQueryHandler : IRequestHandler<GetTotalPagingCustomersQuery, int>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetTotalPagingCustomersQueryHandler(ICustomerRepository customerRepository, IMemberShipTypeRepository memberShipTypeRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<int> Handle(GetTotalPagingCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.CountAsync(x => x.IsDelete == false);
            decimal total = Math.Ceiling((decimal)result / request.size);
            return (int)total;

        }
    }
}
