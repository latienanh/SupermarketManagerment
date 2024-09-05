using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Employee.Commands.CreateEmployee
{
    public sealed record CreateEmployeeCommand(CreateEmployeeRequest CreateEmployeeRequest,Guid UserId) : ICommand<Guid?>;
}
