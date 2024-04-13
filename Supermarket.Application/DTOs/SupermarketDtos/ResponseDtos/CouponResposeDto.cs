using Supermarket.Domain.Entities.SupermarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class CouponResposeDto :  BaseDTO
    {
        public string? Code { get; set; }
        public string? CouponDescripiton { get; set; }
        public double? DiscountValue { get; set; }
        public int? DiscountType { get; set; }
        public DateTime? CouponStartDate { get; set; }
        public DateTime? CouponEndDate { get; set; }

    }
}
