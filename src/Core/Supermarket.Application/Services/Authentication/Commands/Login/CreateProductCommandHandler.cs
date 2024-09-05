using AutoMapper;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Authentication.Commands.Login
{
    public sealed class CreateAttributeCommandHandler : ICommandHandler<CreateAttributeCommand,Guid>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAttributeCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateAttributeCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.SupermarketEntities.Product>(request.product);
            var result =await _productRepository.AddAsync(product,request.userId);
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }


        
    }
}
