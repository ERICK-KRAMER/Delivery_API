using Delivery.Models;

namespace Delivery.Repository.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductById(Guid id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Guid id, Product product);
        Task<bool> DeleteProduct(Guid id);
    }
}
