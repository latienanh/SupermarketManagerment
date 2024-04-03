using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public class CategoryResponseDto:BaseDTO
    {
        public int? ParentId { get; set; }
        public string? CategoryName { get; set; }
    }
}
