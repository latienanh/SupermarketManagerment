using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Employee.Commands.DeleteEmployee
{
    public sealed record DeleteEmployeeCommand(DeleteEmployeeRequest DeleteEmployeeRequest,Guid UserId) : ICommand<Guid?>
    {
    }
}
