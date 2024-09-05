using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Category.Commands.CreateCategory
{
    public sealed record CreateCategoryCommand(CreateCategoryRequest createCategoryRequest,Guid userId) : ICommand<Guid?>;
}
