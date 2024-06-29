using Supermarket.Domain.Entities.SupermarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos
{
    public class StockInDetailRequest
    {
        public Guid? ProductId { get; set; }
        public int QuantityReceived { get; set; }
        public double UnitPriceReceived { get; set; }
        public double? TotalValueReceived { get; set; }

    }
}
