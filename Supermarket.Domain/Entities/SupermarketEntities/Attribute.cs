using System;
using System.Collections.Generic;
using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities
{
    public partial class Attribute : BaseDomain
    {
        public Attribute()
        {
            AttributeValues = new HashSet<AttributeValue>();
        }
        public string? AttributeName { get; set; }
        public virtual ICollection<AttributeValue> AttributeValues { get; set; }
        
    }
}
