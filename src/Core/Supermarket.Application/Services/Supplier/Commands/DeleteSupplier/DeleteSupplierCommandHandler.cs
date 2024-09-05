using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Supplier.Commands.DeleteSupplier
{
    internal class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand,Guid?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierRepository _supplierRepository;
     
        public DeleteSupplierCommandHandler(IMapper mapper,IUnitOfWork unitOfWork,ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _supplierRepository = supplierRepository;
        }
        public async Task<Guid?> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var result = await _supplierRepository.DeleteAsync(request.DeleteSupplierRequest.Id, request.UserId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }
    }
}
