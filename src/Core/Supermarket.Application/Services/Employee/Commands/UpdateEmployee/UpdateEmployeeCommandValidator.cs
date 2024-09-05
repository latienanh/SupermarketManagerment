using FluentValidation;

namespace Supermarket.Application.Services.Employee.Commands.UpdateEmployee
{
    public sealed class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(x => x.Address).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
