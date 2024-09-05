using FluentValidation;

namespace Supermarket.Application.Services.Inventory.Commands.CreateProduct
{
    public class CreateAttributeCommandValidator : AbstractValidator<CreateAttributeRequest>
    {
        public CreateAttributeCommandValidator()
        {
            RuleFor(x=>x.BarCode).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Describe).NotEmpty();
        }
    }
}
