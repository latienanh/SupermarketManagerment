using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Entities.SupermarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class InvoiceDetailResponseDto:BaseDTO
    {
            public Guid? ProductId { get; set; }
            public int? Quantity { get; set; }
            public double? UnitPrice { get; set; }
            public double? TotalPrice { get; set; }
    }
}
