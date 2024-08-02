using Delivery.Data;
using Delivery.Model.Product;
using Delivery.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _dbContext;
        public ProductRepository(AppDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(Guid id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ID == id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(prod => prod.ID == id);
            return product;
        }

        public async Task<Product> UpdateProduct(Guid id, Product updatedProduct)
        {
            var product = await GetProductById(id);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Description = updatedProduct.Description;
                product.Price = updatedProduct.Price;
                product.Category = updatedProduct.Category;
                await _dbContext.SaveChangesAsync();
            }
            return updatedProduct;
        }
    }
}
