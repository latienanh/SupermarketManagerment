using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.User.Commands.UpdateUser
{
    public sealed record UpdateUserCommand(UpdateUserRequest UpdateUserRequest) : ICommand<Guid?>
    {

    }
}
