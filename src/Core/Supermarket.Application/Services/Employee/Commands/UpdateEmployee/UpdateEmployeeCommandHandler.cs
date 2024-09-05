using AutoMapper;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Primitives;

namespace Supermarket.Application.Services.Employee.Commands.UpdateEmployee
{
    public sealed class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand,Guid?>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Guid?> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeUpdate = _mapper.Map<Domain.Entities.SupermarketEntities.Employee>(request.UpdateEmployeeRequest);
            if (request.UpdateEmployeeRequest.PathImage != null)
            {
                employeeUpdate.Image = request.UpdateEmployeeRequest.PathImage;
            }
            var entityType = "Employee";
            var result = await _employeeRepository.updateEmployee(employeeUpdate, entityType, request.UserId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }
    }
}
