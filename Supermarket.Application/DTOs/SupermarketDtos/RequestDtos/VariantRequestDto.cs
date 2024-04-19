using Microsoft.AspNetCore.Http;
using Supermarket.Domain.Entities.SupermarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos
{
    public class VariantRequestDto
    {
        public string? BarCode { get; set; }
        public string? ProductName { get; set; }
        public string? ProductSlug { get; set; }
        public string? ProductImage { get; set; }
        public Guid AttributeId { get; set; }
        public IEnumerable<VariantValueRequestDto> VariantValue { get; set; }
    }
}
