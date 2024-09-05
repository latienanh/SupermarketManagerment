using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Customer.Commands.UpdateCustomer
{
    public sealed record UpdateCustomerCommand(UpdateCustomerRequest CustomerRequest, Guid UserId) : ICommand<Guid?>;

}
