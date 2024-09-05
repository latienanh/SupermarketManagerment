using FluentValidation;

namespace Supermarket.Application.Services.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Describe).NotEmpty();
        }
    }
}
