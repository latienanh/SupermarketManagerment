using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Customer.Commands.DeleteCustomer
{
    internal class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand,Guid?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(IMapper mapper,IUnitOfWork unitOfWork,ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public async Task<Guid?> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.DeleteAsync(request.DeleteCustomerRequest.Id, request.UserId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }
    }
}
