using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Inventory.Queries.SQLServerQueries.GetAllInvoices
{
    public sealed record GetAllInvoicesQuery() : IQuery<IEnumerable<InvoiceResponseDto>>;
}
