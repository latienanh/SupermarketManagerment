using Supermarket.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.DTOs.Common
{
    public class BaseDTO
    {
        public bool? IsDelete { get; set; }
        public int? CreateBy { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public int? ModifiedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public int? DeleteBy { get; set; }
    }
}
