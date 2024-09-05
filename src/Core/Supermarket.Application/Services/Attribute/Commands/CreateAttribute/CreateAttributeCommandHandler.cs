using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Primitives;

namespace Supermarket.Application.Services.Attribute.Commands.CreateAttribute
{
    internal class CreateAttributeCommandHandler : IRequestHandler<CreateAttributeCommand,Guid?>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttributeRepository _attributeRepository;

        public CreateAttributeCommandHandler(IMapper mapper,IUnitOfWork unitOfWork,IAttributeRepository attributeRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _attributeRepository = attributeRepository;
           
        }
        public async Task<Guid?> Handle(CreateAttributeCommand request, CancellationToken cancellationToken)
        {
            var attributeMap = _mapper.Map<Domain.Entities.SupermarketEntities.Attribute>(request.attribute);
            var result = await _attributeRepository.AddAsync(attributeMap,request.userId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }
    }
}
