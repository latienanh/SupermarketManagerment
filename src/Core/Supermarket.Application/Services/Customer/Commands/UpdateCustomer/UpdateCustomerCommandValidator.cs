using FluentValidation;

namespace Supermarket.Application.Services.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
