using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Employee.Commands.UpdateEmployee
{
    public sealed record UpdateEmployeeCommand(UpdateEmployeeRequest UpdateEmployeeRequest,Guid UserId) : ICommand<Guid?>
    {
    }
}
