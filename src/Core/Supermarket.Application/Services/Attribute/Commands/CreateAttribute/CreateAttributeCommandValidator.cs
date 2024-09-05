using FluentValidation;

namespace Supermarket.Application.Services.Attribute.Commands.CreateAttribute
{
    public class CreateAttributeCommandValidator : AbstractValidator<CreateAttributeRequest>
    {
        public CreateAttributeCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(50);
        }
    }
}
