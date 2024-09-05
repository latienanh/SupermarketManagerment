using FluentValidation;

namespace Supermarket.Application.Services.Inventory.Commands.DeleteProduct
{
    public class DeleteAttributeCommandValidator : AbstractValidator<DeleteAttributeRequest>
    {
        public DeleteAttributeCommandValidator()
        {
            RuleFor(x=>x.Id ).NotEmpty();
        }
    }
}
