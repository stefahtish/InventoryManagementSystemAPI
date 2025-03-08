using InventoryManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryDbContext _context;

        public ProductRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        public async Task AddStock(int productId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                product.QuantityInStock += quantity;
                await _context.SaveChangesAsync();
            }
        }
        public async Task WithdrawStock(int productId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null && product.QuantityInStock >= quantity)
            {
                product.QuantityInStock -= quantity;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Insufficient stock.");
            }
        }

        public async Task<List<Product>> GetLowStockItems()
        {
            return await _context.Products
                .Where(p => p.QuantityInStock < p.ReorderLevel)
                .ToListAsync();
        }

        public async Task<decimal> GetInventoryValuation()
        {
            return await _context.Products
                .SumAsync(p => p.UnitPrice * p.QuantityInStock);
        }
    }
}
