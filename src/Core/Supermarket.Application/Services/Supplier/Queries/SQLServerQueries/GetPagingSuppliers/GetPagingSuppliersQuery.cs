using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Supplier.Queries.SQLServerQueries.GetPagingSuppliers
{
    public sealed record GetPagingSuppliersQuery(int index,int size) : IQuery<IEnumerable<SupplierResponseDto>>;

}
