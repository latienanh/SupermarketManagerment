using FluentValidation;

namespace Supermarket.Application.Services.Authentication.Commands.Logout
{
    public class LogoutCommandValidator : AbstractValidator<LogoutRequest>
    {
        public LogoutCommandValidator()
        {
            RuleFor(x=>x.Id ).NotEmpty();
        }
    }
}
