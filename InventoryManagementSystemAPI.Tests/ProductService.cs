using InventoryManagementSystemAPI.Models;
using InventoryManagementSystemAPI.Repositories;

namespace InventoryManagementSystemAPI.InventoryManagementSystemAPI.Tests
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
    }
}
