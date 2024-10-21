using FluentValidation;

namespace Supermarket.Application.Services.Authentication.Commands.RenewToken
{
    public class RenewTokenCommandValidator : AbstractValidator<RenewTokenRequest>
    {
        public RenewTokenCommandValidator()
        {
            RuleFor(x=>x.AccessToken).NotEmpty().MaximumLength(50);
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}
