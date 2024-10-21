using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.MemberShipType.Commands.UpdateMemberShipType
{
    public sealed record UpdateMemberShipTypeCommand(UpdateMemberShipTypeRequest UpdateMemberShipTypeRequest,Guid UserId) : ICommand<Guid?>
    {
    }
}
