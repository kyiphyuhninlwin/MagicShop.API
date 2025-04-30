using Magic_Shop.Data;
using Magic_Shop.Models.Domain;
using Magic_Shop.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Magic_Shop.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        // create and assign field
        private readonly ApplicationDbContext dbContext;

        //ctor to connect with dbcontext
        public ProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteAsync(int productID)
        {
            var existingProduct = await dbContext.Products.FirstOrDefaultAsync(p => p.ID == productID);

            if(existingProduct != null)
            {
                dbContext.Products.Remove(existingProduct);
                await dbContext.SaveChangesAsync();
                return existingProduct;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int productID)
        {
            return await dbContext.Products.FirstOrDefaultAsync(p => p.ID == productID);
        }

        public async Task<Product?> UpdateAsync(Product product)
        {
            var existingProduct = await dbContext.Products.FirstOrDefaultAsync(p => p.ID == product.ID);

            if (existingProduct != null)
            {
                dbContext.Entry(existingProduct).CurrentValues.SetValues(product);
                await dbContext.SaveChangesAsync();
                return existingProduct;
            }
            else
            {
                return null;
            }
        }
    }
}
