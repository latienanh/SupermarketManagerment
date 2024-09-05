using FluentValidation;

namespace Supermarket.Application.Services.Supplier.Commands.UpdateSupplier
{
    public sealed class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierRequest>
    {
        public UpdateSupplierCommandValidator()
        {
            RuleFor(x => x.Address).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
