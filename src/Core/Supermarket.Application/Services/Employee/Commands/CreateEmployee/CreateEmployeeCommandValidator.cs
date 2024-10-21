using FluentValidation;

namespace Supermarket.Application.Services.Employee.Commands.CreateEmployee
{
    public class CreateMemberShipTypeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateMemberShipTypeCommandValidator()
        {
            RuleFor(x=>x.CreateEmployeeRequest.Address).NotEmpty().MaximumLength(50);
            RuleFor(x => x.CreateEmployeeRequest.Email).NotEmpty();
        }
    }
}
