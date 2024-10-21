using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Inventory.Queries.SQLServerQueries.GetSaleDateNow
{
    public sealed record GetSaleDateNowQuery(): IQuery<SaleDateNowResponse>
    {
    }
}
