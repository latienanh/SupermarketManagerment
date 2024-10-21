using FluentValidation;

namespace Supermarket.Application.Services.Inventory.Commands.ImportGoods
{
    public class ImportGoodsCommandValidator : AbstractValidator<ImportGoodsCommand>
    {
        public ImportGoodsCommandValidator()
        {
        }
    }
}
