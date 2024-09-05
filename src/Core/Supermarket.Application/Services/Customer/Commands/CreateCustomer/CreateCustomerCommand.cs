using Supermarket.Application.Abstractions.Messaging;

namespace Supermarket.Application.Services.Customer.Commands.CreateCustomer
{
    public sealed record CreateCustomerCommand(CreateCustomerRequest CreateCustomerRequest,Guid userId) : ICommand<Guid?>;
}
