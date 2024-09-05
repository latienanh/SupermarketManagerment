using AutoMapper;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Primitives;

namespace Supermarket.Application.Services.Supplier.Commands.CreateSupplier
{
    public sealed class CreateSupplierCommandHandler : ICommandHandler<CreateSupplierCommand,Guid?>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid?> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = _mapper.Map<Domain.Entities.SupermarketEntities.Supplier>(request.CreateSupplierRequest);
            var result = await _supplierRepository.AddAsync(supplier, request.userId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }


        
    }
}
