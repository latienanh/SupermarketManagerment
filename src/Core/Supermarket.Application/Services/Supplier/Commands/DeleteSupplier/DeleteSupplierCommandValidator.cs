using FluentValidation;

namespace Supermarket.Application.Services.Supplier.Commands.DeleteSupplier
{
    public class DeleteSupplierCommandValidator : AbstractValidator<DeleteSupplierRequest>
    {
        public DeleteSupplierCommandValidator()
        {
            RuleFor(x=>x.Id ).NotEmpty();
        }
    }
}
