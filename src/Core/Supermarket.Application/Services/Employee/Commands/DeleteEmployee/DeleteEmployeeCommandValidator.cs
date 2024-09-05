using FluentValidation;

namespace Supermarket.Application.Services.Employee.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeRequest>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(x=>x.Id ).NotEmpty();
        }
    }
}
