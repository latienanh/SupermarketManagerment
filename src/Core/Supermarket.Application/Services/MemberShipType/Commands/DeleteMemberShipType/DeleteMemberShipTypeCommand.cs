using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.MemberShipType.Commands.DeleteMemberShipType
{
    public sealed record DeleteMemberShipTypeCommand(DeleteMemberShipTypeRequest DeleteMemberShipTypeRequest,Guid UserId) : ICommand<Guid?>
    {
    }
}
