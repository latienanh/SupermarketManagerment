using AutoMapper;
using MediatR;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;

namespace Supermarket.Application.Services.MemberShipType.Commands.DeleteMemberShipType
{
    internal class DeleteMemberShipTypeCommandHandler : IRequestHandler<DeleteMemberShipTypeCommand,Guid?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemberShipTypeRepository _memberShipTypeRepository;

        public DeleteMemberShipTypeCommandHandler(IUnitOfWork unitOfWork,IMemberShipTypeRepository memberShipTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _memberShipTypeRepository = memberShipTypeRepository;
        }
        public async Task<Guid?> Handle(DeleteMemberShipTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _memberShipTypeRepository.DeleteAsync(request.DeleteMemberShipTypeRequest.Id, request.UserId);
            if (result == null)
                return null;
            await _unitOfWork.CommitAsync(cancellationToken);
            return result.Id;
        }
    }
}
