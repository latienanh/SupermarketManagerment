using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Employee.Queries.SQLServerQueries.GetTotalPagingEmployees
{
    public class GetTotalPagingEmployeesQueryHandler : IRequestHandler<GetTotalPagingEmployeesQuery,int>
    {

        private readonly IEmployeeRepository _employeeRepository;
        public GetTotalPagingEmployeesQueryHandler( IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> Handle(GetTotalPagingEmployeesQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.CountAsync(x => x.IsDelete == false);
            decimal total = Math.Ceiling((decimal)result / request.size);
            return (int)total;

        }
    }
}
