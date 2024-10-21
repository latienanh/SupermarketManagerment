using MediatR;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.DTOs.Auth.ResponseDtos;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.Services.User.Queries.SQLServerQueries.GetPagingUsers
{
    public sealed record GetPagingUsersQuery(int index,int size) : IQuery<IEnumerable<UserResponseDto>>;

}
