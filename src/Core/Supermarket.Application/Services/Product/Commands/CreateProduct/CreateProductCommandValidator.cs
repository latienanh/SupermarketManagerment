using FluentValidation;

namespace Supermarket.Application.Services.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x=>x.BarCode).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Describe).NotEmpty();
        }
    }
}
