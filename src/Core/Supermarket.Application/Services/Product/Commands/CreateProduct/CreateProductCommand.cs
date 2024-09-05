using MediatR;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;

namespace Supermarket.Application.Services.Product.Commands.CreateProduct
{
    public sealed record CreateAttributeCommand(CreateAttributeRequest product,Guid userId) : ICommand<Guid>;
}
