using FluentValidation;

namespace Supermarket.Application.Services.Authentication.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.LoginRequest.UserName)
                .NotEmpty().WithMessage("Chưa nhập UserName")
                .MaximumLength(50).WithMessage("Dài quá");

            RuleFor(x => x.LoginRequest.Password)
                .NotEmpty().WithMessage("Chưa nhập Password");
        }
    }
}
