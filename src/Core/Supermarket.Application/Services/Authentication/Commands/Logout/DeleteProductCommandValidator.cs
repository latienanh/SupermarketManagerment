using FluentValidation;

namespace Supermarket.Application.Services.Authentication.Commands.Logout
{
    public class DeleteAttributeCommandValidator : AbstractValidator<DeleteAttributeRequest>
    {
        public DeleteAttributeCommandValidator()
        {
            RuleFor(x=>x.Id ).NotEmpty();
        }
    }
}
