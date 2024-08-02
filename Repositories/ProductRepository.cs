using Delivery.Data;
using Delivery.Models;
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
            var product = await GetProductById(id);
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
            return await _dbContext.Products.FirstOrDefaultAsync(product => product.ID == id);
        }

        public async Task<Product> UpdateProduct(Guid id, Product product)
        {
            var findProduct = await GetProductById(id);
            if (findProduct != null)
            {
                findProduct.Name = product.Name;
                findProduct.Description = product.Description;
                findProduct.Price = product.Price;
                findProduct.Category = product.Category;
                await _dbContext.SaveChangesAsync();
                return findProduct;
            }
            return product;
        }
    }
}
