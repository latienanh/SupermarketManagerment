using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Primitives;

namespace Supermarket.Application.Services.Attribute.Commands.UpdateAttribute
{
    internal class UpdateAttributeCommandHandler : IRequestHandler<UpdateAttributeCommand,Guid?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttributeRepository _attributeRepository;

        public UpdateAttributeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork,
            IAttributeRepository attributeRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _attributeRepository = attributeRepository;
        }
        public async Task<Guid?> Handle(UpdateAttributeCommand request, CancellationToken cancellationToken)
        {
            var attributeValue = _mapper.Map<Domain.Entities.SupermarketEntities.Attribute>(request.updateAttributeRequest);
            var entityType = "Attribute";
            var result = await _attributeRepository.UpdateAsync(attributeValue, entityType, request.UserId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }
    }
}
