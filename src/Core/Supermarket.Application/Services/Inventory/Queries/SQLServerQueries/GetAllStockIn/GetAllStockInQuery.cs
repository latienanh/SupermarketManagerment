using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Inventory.Queries.SQLServerQueries.GetAllStockIn
{
    public sealed record GetAllStockInQuery() : IQuery<IEnumerable<StockInResponseDto>>;
}
