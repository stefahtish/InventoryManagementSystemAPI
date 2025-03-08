using InventoryManagementSystemAPI.Models;

namespace InventoryManagementSystemAPI.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task AddStock(int productId, int quantity);
        Task WithdrawStock(int productId, int quantity);
        Task<List<Product>> GetLowStockItems();
        Task<decimal> GetInventoryValuation();
    }
}
