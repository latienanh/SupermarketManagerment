using AutoMapper;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Customer.Commands.CreateCustomer
{
    public sealed class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand,Guid?>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid?> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entityMap = _mapper.Map<Domain.Entities.SupermarketEntities.Customer>(request.CreateCustomerRequest);
            var result = await _customerRepository.AddAsync(entityMap,request.userId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }


        
    }
}
