using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.MemberShipType.Commands.CreateMemberShipType
{
    public sealed record CreateMemberShipTypeCommand(CreateMemberShipTypeRequest CreateMemberShipTypeRequest,Guid UserId) : ICommand<Guid?>;
}
