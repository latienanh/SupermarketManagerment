using Supermarket.Domain.Entities.SupermarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class ProductResponseDto : BaseDTO
    {
        public string? BarCode { get; set; }
        public string? ProductName { get; set; }
        public string? ProductSlug { get; set; }
        public string? ProductImage { get; set; }
        public int? ParentId { get; set; }
        public int? Quantity { get; set; }
        public IEnumerable<CategoryResponseDto> Categories { get; set; }
    }
}
