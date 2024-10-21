using FluentValidation;

namespace Supermarket.Application.Services.Employee.Commands.UpdateEmployee
{
    public sealed class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(x => x.UpdateEmployeeRequest.Address).NotEmpty().MaximumLength(50);
            RuleFor(x => x.UpdateEmployeeRequest.Email).NotEmpty();
        }
    }
}
