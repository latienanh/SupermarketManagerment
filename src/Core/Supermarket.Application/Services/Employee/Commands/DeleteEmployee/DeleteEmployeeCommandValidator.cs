using FluentValidation;

namespace Supermarket.Application.Services.Employee.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(x=>x.DeleteEmployeeRequest.Id ).NotEmpty();
        }
    }
}
