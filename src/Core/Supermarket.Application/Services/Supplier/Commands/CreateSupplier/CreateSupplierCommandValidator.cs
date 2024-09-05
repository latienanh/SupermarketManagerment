using FluentValidation;

namespace Supermarket.Application.Services.Supplier.Commands.CreateSupplier
{
    public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierRequest>
    {
        public CreateSupplierCommandValidator()
        {
            RuleFor(x=>x.Address).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
