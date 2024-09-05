using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Employee.Commands.DeleteEmployee
{
    internal class CreateAttributeCommandHandler : IRequestHandler<DeleteEmployeeCommand,Guid?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;

        public CreateAttributeCommandHandler(IMapper mapper,IUnitOfWork unitOfWork,IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
        }
        public async Task<Guid?> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.DeleteAsync(request.DeleteEmployeeRequest.Id, request.UserId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }
    }
}
