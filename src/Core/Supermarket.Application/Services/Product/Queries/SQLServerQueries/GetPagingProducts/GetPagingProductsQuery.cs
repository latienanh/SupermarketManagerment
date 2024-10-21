using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Product.Queries.SQLServerQueries.GetPagingProducts
{
    public sealed record GetPagingProductsQuery(int index,int size) : IQuery<IEnumerable<ProductsPagingResponseDto>>;

}
