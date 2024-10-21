

namespace Supermarket.Application.Services.Inventory.Commands.ImportGoods
{
    public sealed record ImportGoodsRequest
    {
        public Guid SupplierId { get; set; }
        public DateTime? EntryDate { get; set; }
        public Guid EmployeeId { get; set; }
        public double? TotalOrderValue { get; set; }
        public string? Note { get; set; }
        public ICollection<StockInDetailRequest> StockInDetails { get; set; }
    }
}
