using AutoMapper;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Primitives;

namespace Supermarket.Application.Services.Supplier.Commands.UpdateSupplier
{
    public sealed class UpdateSupplierCommandHandler : ICommandHandler<UpdateSupplierCommand,Guid?>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Guid?> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            
            var supplierUpdate = _mapper.Map<Domain.Entities.SupermarketEntities.Supplier>(request.UpdateSupplierRequest);

            var entityType = "Supplier";
            var result = await _supplierRepository.UpdateAsync(supplierUpdate, entityType,request.UserId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }
    }
}
