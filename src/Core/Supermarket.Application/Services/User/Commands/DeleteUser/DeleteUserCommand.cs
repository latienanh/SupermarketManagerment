using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.User.Commands.DeleteUser
{
    public sealed record DeleteUserCommand(DeleteUserRequest DeleteUserRequest) : ICommand<Guid?>
    {
    }
}
