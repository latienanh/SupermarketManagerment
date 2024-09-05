using FluentValidation;

namespace Supermarket.Application.Services.User.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50);
            RuleFor(x => x.FirstName).NotEmpty();
        }

    }
}
