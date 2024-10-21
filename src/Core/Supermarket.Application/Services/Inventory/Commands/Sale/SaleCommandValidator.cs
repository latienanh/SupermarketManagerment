using FluentValidation;

namespace Supermarket.Application.Services.Inventory.Commands.Sale
{
    public class SaleCommandValidator : AbstractValidator<SaleCommand>
    {
        public SaleCommandValidator()
        {
        }
    }
}
