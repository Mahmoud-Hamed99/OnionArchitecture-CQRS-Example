using Products.Domain;

namespace Products.Service
{
    public class ProductViewModel
    {
        public int ProductId { get;  set; }

        public string? Name { get; set; } 

        public string? Brand { get; set; }

        public virtual ICollection<ProductDetailsViewModel> ProductDetails { get; set; } = new List<ProductDetailsViewModel>();
    }
}
