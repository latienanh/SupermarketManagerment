﻿using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class Attribute : BaseDomain
{
    public Attribute()
    {
        AttributeValues = new HashSet<VariantValue>();
    }

    public string? AttributeName { get; set; }
    public virtual ICollection<VariantValue> AttributeValues { get; set; }
}