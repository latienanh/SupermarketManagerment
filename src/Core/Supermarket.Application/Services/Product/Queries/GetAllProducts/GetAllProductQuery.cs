using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.Product.Queries.GetAllProducts
{
    public sealed record GetAllAttributeQuery() : IQuery<IEnumerable<ProductResponseDto>>;
}
