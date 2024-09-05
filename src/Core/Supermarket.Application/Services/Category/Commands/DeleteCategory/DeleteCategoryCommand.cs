using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Category.Commands.DeleteCategory
{
    public sealed record DeleteCategoryCommand(DeleteCategoryRequest DeleteCategoryRequest,Guid UserId) : ICommand<Guid?>
    {
    }
}
