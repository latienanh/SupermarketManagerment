using FluentValidation;

namespace Supermarket.Application.Services.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
