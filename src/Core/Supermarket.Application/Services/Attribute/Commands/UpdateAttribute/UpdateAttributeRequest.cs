using Supermarket.Application.Common;

namespace Supermarket.Application.Services.Attribute.Commands.UpdateAttribute
{
    public sealed record UpdateAttributeRequest(string Name):BaseDTORequestUpdate;
}
