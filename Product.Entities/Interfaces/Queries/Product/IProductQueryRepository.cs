namespace Products.Domain
{
    public interface IProductQueryRepository
    {
       Task<List<Product>> GetAll();

       Task<Product> GetById(int id);
    }
}
