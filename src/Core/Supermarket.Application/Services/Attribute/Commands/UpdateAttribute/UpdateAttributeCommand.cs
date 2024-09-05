using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Attribute.Commands.UpdateAttribute
{
   
        public sealed record UpdateAttributeCommand(UpdateAttributeRequest updateAttributeRequest, Guid UserId) : ICommand<Guid?>
        {
        }
    
}
