using FluentValidation;

namespace Supermarket.Application.Services.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x=>x.Id ).NotEmpty();
        }
    }
}
