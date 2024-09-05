using Supermarket.Application.Common;

namespace Supermarket.Application.Services.Supplier.Commands.UpdateSupplier
{
    public sealed record UpdateSupplierRequest : BaseDTORequestUpdate
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
