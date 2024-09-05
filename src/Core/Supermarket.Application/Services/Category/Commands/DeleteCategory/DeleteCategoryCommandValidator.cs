using FluentValidation;

namespace Supermarket.Application.Services.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryRequest>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x=>x.Id ).NotEmpty();
        }
    }
}
