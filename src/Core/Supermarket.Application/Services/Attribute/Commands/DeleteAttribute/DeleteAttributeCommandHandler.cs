using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.Attribute.Commands.DeleteAttribute
{
    internal class DeleteAttributeCommandHandler : IRequestHandler<DeleteAttributeCommand,Guid?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttributeRepository _attributeRepository;

        public DeleteAttributeCommandHandler(IUnitOfWork unitOfWork,IAttributeRepository attributeRepository)
        {
            _unitOfWork = unitOfWork;
            _attributeRepository = attributeRepository;
            
        }
        public async Task<Guid?> Handle(DeleteAttributeCommand request, CancellationToken cancellationToken)
        {
            var result = await _attributeRepository.DeleteAsync(request.deleteAttributeRequest.Id, request.UserId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }
    }
}
