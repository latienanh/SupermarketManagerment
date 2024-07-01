using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class DailySaleData
    {
        public DateTime Date { get; set; }
        public float TotalPrice { get; set; }
        public int Quantity { get; set; }
    }
  
}
