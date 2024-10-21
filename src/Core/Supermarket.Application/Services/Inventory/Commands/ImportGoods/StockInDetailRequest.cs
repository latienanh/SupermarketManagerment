namespace Supermarket.Application.Services.Inventory.Commands.ImportGoods
{
    public class StockInDetailRequest
    {
        public Guid? ProductId { get; set; }
        public int QuantityReceived { get; set; }
        public double UnitPriceReceived { get; set; }
        public double? TotalValueReceived { get; set; }
    }
}
