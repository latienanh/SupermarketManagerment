using FluentValidation;

namespace Supermarket.Application.Services.Attribute.Commands.UpdateAttribute
{
    public class UpdateAttributeCommandValidator : AbstractValidator<UpdateAttributeRequest>
    {
        public UpdateAttributeCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
