using Microsoft.AspNetCore.Http;

namespace Supermarket.Application.Services.Employee.Commands.UpdateEmployee
{
    public sealed record UpdateEmployeeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IFormFile? Image { get; set; }
        public string? PathImage { get; set; }
    }
}
