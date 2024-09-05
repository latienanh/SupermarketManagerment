using FluentValidation;

namespace Supermarket.Application.Services.User.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x=>x.Id ).NotEmpty();
        }
    }
}
