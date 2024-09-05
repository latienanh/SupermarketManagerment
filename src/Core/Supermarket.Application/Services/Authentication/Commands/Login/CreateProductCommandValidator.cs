using FluentValidation;

namespace Supermarket.Application.Services.Authentication.Commands.Login
{
    public class CreateAttributeCommandValidator : AbstractValidator<CreateAttributeRequest>
    {
        public CreateAttributeCommandValidator()
        {
            RuleFor(x=>x.BarCode).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Describe).NotEmpty();
        }
    }
}
