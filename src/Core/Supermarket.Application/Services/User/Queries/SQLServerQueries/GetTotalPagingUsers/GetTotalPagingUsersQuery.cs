using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.User.Queries.SQLServerQueries.GetTotalPagingUsers
{
    public sealed record GetTotalPagingUsersQuery(int size) : IQuery<int>;

}
