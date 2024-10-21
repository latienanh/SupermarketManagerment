using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Supplier.Queries.SQLServerQueries.GetAllSuppliers
{
    public sealed record GetAllSuppliersQuery() : IQuery<IEnumerable<SupplierResponseDto>>;
}
