using AutoMapper;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Primitives;

namespace Supermarket.Application.Services.Customer.Commands.UpdateCustomer
{
    public sealed class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand,Guid?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }
        public async Task<Guid?> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var CustomerValue = _mapper.Map<Domain.Entities.SupermarketEntities.Customer>(request.CustomerRequest);
            var entityType = "Customer";
            var result = await _customerRepository.UpdateAsync(CustomerValue, entityType, request.UserId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }
    }
}
