using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class StockInResponseDto
    {
        public Guid SupplierId { get; set; }
        public DateTime? EntryDate { get; set; }
        public Guid EmployeeId { get; set; }
        public double? TotalOrderValue { get; set; }
        public string? Note { get; set; }
        //public virtual ICollection<StockInDetailRequest> StockInDetails { get; set; }
    }
}
