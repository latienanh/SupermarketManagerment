using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;

namespace Supermarket.Application.Services.Employee.Queries.SQLServerQueries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler: IRequestHandler<GetEmployeeByIdQuery,EmployeeResponseDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;

        }
        public async Task<EmployeeResponseDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.GetSingleByIdAsync(request.id);
            return _mapper.Map<EmployeeResponseDto>(result);
        }
    }
}
