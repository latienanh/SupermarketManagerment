using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Customer.Commands.DeleteCustomer
{
    public sealed record DeleteCustomerCommand(DeleteCustomerRequest DeleteCustomerRequest,Guid UserId) : ICommand<Guid?>
    {
    }
}
