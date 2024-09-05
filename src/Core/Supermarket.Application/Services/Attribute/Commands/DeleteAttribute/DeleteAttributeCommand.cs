using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Attribute.Commands.DeleteAttribute
{
    public sealed record DeleteAttributeCommand(DeleteAttributeRequest deleteAttributeRequest,Guid UserId) : ICommand<Guid?>
    {
    }
}
