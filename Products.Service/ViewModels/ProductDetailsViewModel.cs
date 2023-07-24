using Products.Domain;

namespace Products.Service
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int? Size { get; set; }

        public string? Color { get; set; }

        public double? Cost { get; set; }
      //  public virtual Product Product { get; set; } 

    }
}
