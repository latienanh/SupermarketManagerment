using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Authentication.Commands.Logout
{
    internal class CreateAttributeCommandHandler : IRequestHandler<DeleteAttributeCommand,Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public CreateAttributeCommandHandler(IMapper mapper,IUnitOfWork unitOfWork,IProductRepository productRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        public async Task<Guid> Handle(DeleteAttributeCommand request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.DeleteAsync(request.Id,request.UserId);
            return result.Id;
        }
    }
}
