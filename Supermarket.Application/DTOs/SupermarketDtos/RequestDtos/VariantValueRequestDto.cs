using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos
{
    public class VariantValueRequestDto
    {
        public Guid AttributeId { get; set; }
        public string VariantValue { get; set; }
    }
}
