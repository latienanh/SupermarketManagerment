﻿using Supermarket.Domain.Entities.Common;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class VariantValue : BaseDomain
{
    public Guid? AttributeId { get; set; }
    public Guid? ProductId { get; set; }
    public string? AttributeValueName { get; set; }

    public virtual Attribute? Attribute { get; set; }
    public virtual Product? Product { get; set; }
}