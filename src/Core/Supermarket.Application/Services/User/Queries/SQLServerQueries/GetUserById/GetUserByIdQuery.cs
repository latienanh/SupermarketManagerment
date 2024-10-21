using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;

namespace Supermarket.Application.Services.User.Queries.SQLServerQueries.GetUserById
{
    public sealed record GetUserByIdQuery(Guid id) : IQuery<UserResponseDto>;

}
