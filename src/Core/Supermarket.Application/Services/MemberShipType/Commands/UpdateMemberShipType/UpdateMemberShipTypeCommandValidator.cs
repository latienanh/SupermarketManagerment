using FluentValidation;

namespace Supermarket.Application.Services.MemberShipType.Commands.UpdateMemberShipType
{
    public sealed class UpdateMemberShipTypeCommandValidator : AbstractValidator<UpdateMemberShipTypeCommand>
    {
        
        public UpdateMemberShipTypeCommandValidator()
        {
            RuleFor(x => x.UpdateMemberShipTypeRequest.Name).NotEmpty().MaximumLength(50);
        }
    }
}
