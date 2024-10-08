﻿using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Primitives;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class InvoiceDetail : Entity
{
    public Guid? ProductId { get; set; }
    public Guid? InvoiceId { get; set; }
    public int? Quantity { get; set; }
    public double? UnitPrice { get; set; }
    public double? TotalPrice { get; set; }
    public virtual Invoice Invoice { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}