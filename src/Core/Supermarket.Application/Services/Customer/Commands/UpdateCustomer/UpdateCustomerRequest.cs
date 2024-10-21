using Supermarket.Application.Common;

namespace Supermarket.Application.Services.Customer.Commands.UpdateCustomer
{
    public sealed record UpdateCustomerRequest:BaseDTORequestUpdate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid MembershipTypeId { get; set; }
    }
}
