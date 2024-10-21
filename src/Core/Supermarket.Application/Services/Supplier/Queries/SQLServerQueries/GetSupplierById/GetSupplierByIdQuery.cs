using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Supplier.Queries.SQLServerQueries.GetSupplierById
{
    public sealed record GetSupplierByIdQuery(Guid id) : IQuery<SupplierResponseDto>;

}
