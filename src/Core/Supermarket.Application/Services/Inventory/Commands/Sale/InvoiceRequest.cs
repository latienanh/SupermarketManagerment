namespace Supermarket.Application.Services.Inventory.Commands.Sale
{
    public sealed record InvoiceRequest()
    {
        public Guid? CustomerId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public double? TotalPrice { get; set; }
        public int? PaymentStatus { get; set; }
        public string? PaymentMethod { get; set; }
        public  ICollection<InvoiceDetailRequest> InvoiceDetails { get; set; }
    };
}
