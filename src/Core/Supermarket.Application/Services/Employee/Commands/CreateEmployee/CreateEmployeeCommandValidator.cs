using FluentValidation;

namespace Supermarket.Application.Services.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x=>x.Address).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
