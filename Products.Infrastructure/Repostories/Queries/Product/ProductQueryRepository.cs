using Microsoft.EntityFrameworkCore;
using Products.Domain;

namespace Products.Infrastructure
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        ProductContext _dbContext;
        public ProductQueryRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAll()
        {
            try
            {

                var res = await _dbContext.Products.Include(a => a.ProductDetails).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                var x = ex;
                return null;
            }
        }

        public async Task<Product> GetById(int id)
        {
            return await _dbContext.Products.Include(a => a.ProductDetails).FirstOrDefaultAsync(b => b.ProductId == id);
        }
    }
}
