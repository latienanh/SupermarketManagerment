using FluentValidation;

namespace Supermarket.Application.Services.MemberShipType.Commands.CreateMemberShipType
{
    public class CreateMemberShipTypeCommandValidator : AbstractValidator<CreateMemberShipTypeCommand>
    {
        public CreateMemberShipTypeCommandValidator()
        {
            RuleFor(x=>x.CreateMemberShipTypeRequest.Name).NotEmpty().MaximumLength(50);
        }
    }
}
