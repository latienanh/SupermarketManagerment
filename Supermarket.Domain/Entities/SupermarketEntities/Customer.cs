using System;
using System.Collections.Generic;
using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities
{
    public partial class Customer : BaseDomain
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? MembershipTypeId { get; set; }

        public virtual MemberShipType? MembershipType { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
