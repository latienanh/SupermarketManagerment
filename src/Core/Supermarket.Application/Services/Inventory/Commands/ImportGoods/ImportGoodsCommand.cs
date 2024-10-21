using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Inventory.Commands.ImportGoods
{
    public sealed record ImportGoodsCommand(ImportGoodsRequest ImportGoodsRequest,Guid userId) : ICommand<Guid?>;
}
