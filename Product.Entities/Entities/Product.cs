using System;
using System.Collections.Generic;

namespace Products.Domain;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Brand { get; set; }

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
}
