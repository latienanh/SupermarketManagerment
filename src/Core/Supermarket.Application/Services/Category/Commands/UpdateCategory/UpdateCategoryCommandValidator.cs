using FluentValidation;

namespace Supermarket.Application.Services.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
        }
    }
}
