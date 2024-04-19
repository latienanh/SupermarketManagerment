using Supermarket.Domain.Entities.SupermarketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos
{
    public class ProductRequestDto
    {
        public string? BarCode { get; set; }
        public string? ProductName { get; set; }
        public string? ProductSlug { get; set; }
        public string? ProductImage { get; set; }
        public IEnumerable<Guid>? CategoriesId { get; set; }
        public IEnumerable<VariantRequestDto>? Variants { get; set; } 
    }
}
