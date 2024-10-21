using FluentValidation;

namespace Supermarket.Application.Services.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.BarCode).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Describe).NotEmpty();
        }
    }
}
