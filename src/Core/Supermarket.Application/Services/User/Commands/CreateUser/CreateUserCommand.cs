using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.User.Commands.CreateUser
{
    public sealed record CreateUserCommand(CreateUserRequest CreateUserRequest) : ICommand<Guid?>;
}
