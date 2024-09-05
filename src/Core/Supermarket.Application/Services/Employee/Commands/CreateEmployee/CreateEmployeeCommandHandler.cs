using AutoMapper;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Employee.Commands.CreateEmployee
{
    public sealed class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand,Guid?>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid?> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Domain.Entities.SupermarketEntities.Employee>(request.CreateEmployeeRequest);
            employee.Image = request.CreateEmployeeRequest.PathImage;
            var result = await _employeeRepository.AddAsync(employee, request.UserId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }


        
    }
}
