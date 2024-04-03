using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class AttributeValueResponseDto: BaseDTO
    {
        public int? AttributeId { get; set; }
        public string? AttributeValue1 { get; set; }
    }
}
