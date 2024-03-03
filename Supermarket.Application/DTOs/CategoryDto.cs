using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs.Common;
using Supermarket.Domain.Entities;

namespace Supermarket.Application.DTOs
{
    public class CategoryDto : BaseDTO
    {
        public int? ParentId { get; set; }
        public string? CategoryName { get; set; }
    }
}
