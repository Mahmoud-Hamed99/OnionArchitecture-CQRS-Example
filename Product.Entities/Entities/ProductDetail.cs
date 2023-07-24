using System;
using System.Collections.Generic;

namespace Products.Domain;

public partial class ProductDetail
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int Size { get; set; }

    public string Color { get; set; } = null!;

    public double Cost { get; set; }

    public virtual Product Product { get; set; } = null!;
}
