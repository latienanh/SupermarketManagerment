using AutoMapper;
using MediatR;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using System.Drawing;

namespace Supermarket.Application.Services.Employee.Queries.SQLServerQueries.GetPagingEmployees
{
    public class GetPagingEmployeesQueryHandler : IRequestHandler<GetPagingEmployeesQuery, IEnumerable<EmployeeResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        public GetPagingEmployeesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<EmployeeResponseDto>> Handle(GetPagingEmployeesQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.GetMultiPagingAsync(x => x.IsDelete == false, request.index, request.size);
            var resultMap = _mapper.Map<IEnumerable<EmployeeResponseDto>>(result);
            return resultMap;
        }
    }
}
