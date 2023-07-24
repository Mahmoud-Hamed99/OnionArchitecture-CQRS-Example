using Microsoft.EntityFrameworkCore;
using Products.Domain;

namespace Products.Infrastructure
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        ProductContext _dbContext;
        public ProductCommandRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var res =await _dbContext.Products.AddAsync(product);

            _dbContext.SaveChanges();

            return  res.Entity;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var res = _dbContext.Products.Update(product);

            await _dbContext.SaveChangesAsync();

            return  res.Entity;

        }
    }
}
