namespace Products.Domain
{
    public interface IProductCommandRepository
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
    }
}
