using FluentValidation;

namespace Supermarket.Application.Services.Attribute.Commands.DeleteAttribute
{
    public class DeleteAttributeCommandValidator : AbstractValidator<DeleteAttributeRequest>
    {
        public DeleteAttributeCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
        }
    }
}
