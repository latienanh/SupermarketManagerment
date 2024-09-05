using FluentValidation;

namespace Supermarket.Application.Services.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().MaximumLength(50);
            RuleFor(x => x.FirstName).NotEmpty();
        }
    }
}
