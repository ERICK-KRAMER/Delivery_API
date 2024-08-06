using Delivery.Models;
using Delivery.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productRepository.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            Product createdProduct = await _productRepository.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.ID }, createdProduct);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product, Guid id)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var updatedProduct = await _productRepository.UpdateProduct(id, product);
            return Ok(updatedProduct);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var removedProduct = await _productRepository.DeleteProduct(id);
            return Ok(removedProduct);
        }
    }
}
