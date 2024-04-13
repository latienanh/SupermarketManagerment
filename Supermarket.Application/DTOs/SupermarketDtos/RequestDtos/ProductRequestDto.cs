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
        public int? CategoryId { get; set; }
        public int? ParentId { get; set; }
        public IFormFile image { get; set; }

        public IEnumerable<int> CategoriesId { get; set; }

    }
}
