using FluentValidation;

namespace Supermarket.Application.Services.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x=>x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
