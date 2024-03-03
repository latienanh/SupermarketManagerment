using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Domain.Entities.SupermarketEntities
{
    public class Employee : BaseDomain
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int UserId { get; set; }
    }
}
