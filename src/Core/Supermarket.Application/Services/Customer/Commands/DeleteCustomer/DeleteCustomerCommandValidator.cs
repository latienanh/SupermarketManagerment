using FluentValidation;

namespace Supermarket.Application.Services.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerRequest>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
        }
    }
}
