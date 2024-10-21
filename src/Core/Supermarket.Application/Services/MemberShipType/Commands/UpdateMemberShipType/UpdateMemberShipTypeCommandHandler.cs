using AutoMapper;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Primitives;

namespace Supermarket.Application.Services.MemberShipType.Commands.UpdateMemberShipType
{
    public sealed class UpdateMemberShipTypeCommandHandler : ICommandHandler<UpdateMemberShipTypeCommand,Guid?>
    {
        private readonly IMemberShipTypeRepository _memberShipTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMemberShipTypeCommandHandler(IMemberShipTypeRepository memberShipTypeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _memberShipTypeRepository = memberShipTypeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Guid?> Handle(UpdateMemberShipTypeCommand request, CancellationToken cancellationToken)
        {
            var MemberShipTypeValue = _mapper.Map<Domain.Entities.SupermarketEntities.MemberShipType>(request.UpdateMemberShipTypeRequest);
            var entityType = "MemberShipType";
            var result = await _memberShipTypeRepository.UpdateAsync(MemberShipTypeValue, entityType,request.UserId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }
    }
}
