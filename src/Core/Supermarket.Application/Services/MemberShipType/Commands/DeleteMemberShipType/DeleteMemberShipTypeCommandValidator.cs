using FluentValidation;

namespace Supermarket.Application.Services.MemberShipType.Commands.DeleteMemberShipType
{
    public class DeleteMemberShipTypeCommandValidator : AbstractValidator<DeleteMemberShipTypeCommand>
    {
        public DeleteMemberShipTypeCommandValidator()
        {
            RuleFor(x=>x.DeleteMemberShipTypeRequest.Id ).NotEmpty();
        }
    }
}
