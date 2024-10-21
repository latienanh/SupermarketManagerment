using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Inventory.Queries.SQLServerQueries.GetChartSale
{
    public sealed record GetChartSaleQuery(): IQuery<SaleDateNow1Response>
    {
    }
}
