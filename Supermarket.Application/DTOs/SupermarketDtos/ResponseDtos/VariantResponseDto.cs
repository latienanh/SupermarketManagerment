using Supermarket.Domain.Entities.SupermarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class VariantResponseDto : BaseDTO
    {
        public string? Title { get; set; }
        public double? BuyingPrice { get; set; }
        public double? SalePrice { get; set; }
        public int? AttributeValueId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public string? Sku { get; set; }
        public string? ImageProductVariant { get; set; }
        
    }
}
