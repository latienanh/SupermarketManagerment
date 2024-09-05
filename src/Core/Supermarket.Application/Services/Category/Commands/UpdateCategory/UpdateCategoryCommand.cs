using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Category.Commands.UpdateCategory
{
    public sealed record UpdateCategoryCommand
        (UpdateCategoryRequest UpdateCategoryRequest, Guid UserId) : ICommand<Guid?>
    {
    };

}
