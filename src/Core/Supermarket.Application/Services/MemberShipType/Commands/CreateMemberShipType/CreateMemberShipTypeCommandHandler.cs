using AutoMapper;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Primitives;

namespace Supermarket.Application.Services.MemberShipType.Commands.CreateMemberShipType
{
    public sealed class CreateMemberShipTypeCommandHandler : ICommandHandler<CreateMemberShipTypeCommand,Guid?>
    {
        private readonly IMemberShipTypeRepository _memberShipTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMemberShipTypeCommandHandler(IMemberShipTypeRepository memberShipTypeRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _memberShipTypeRepository = memberShipTypeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid?> Handle(CreateMemberShipTypeCommand request, CancellationToken cancellationToken)
        {
         
            var entityMap = _mapper.Map<Domain.Entities.SupermarketEntities.MemberShipType>(request.CreateMemberShipTypeRequest);
            var result = await _memberShipTypeRepository.AddAsync(entityMap, request.UserId);
            if (result == null)
                return 
                    null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }


        
    }
}
