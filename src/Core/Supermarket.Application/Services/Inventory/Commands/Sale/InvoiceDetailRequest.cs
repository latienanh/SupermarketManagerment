namespace Supermarket.Application.Services.Inventory.Commands.Sale
{
    public class InvoiceDetailRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double? TotalPrice { get; set; }

    }
}
