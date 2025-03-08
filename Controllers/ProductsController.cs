using InventoryManagementSystemAPI.Models;
using InventoryManagementSystemAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _productRepository.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            await _productRepository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/add-stock")]
        public async Task<IActionResult> AddStock(int id, [FromBody] int quantity)
        {
            await _productRepository.AddStock(id, quantity);
            return NoContent();
        }

        [HttpPost("{id}/withdraw-stock")]
        public async Task<IActionResult> WithdrawStock(int id, [FromBody] int quantity)
        {
            await _productRepository.WithdrawStock(id, quantity);
            return NoContent();
        }

        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStockItems()
        {
            var lowStockItems = await _productRepository.GetLowStockItems();
            return Ok(lowStockItems);
        }

        [HttpGet("inventory-valuation")]
        public async Task<IActionResult> GetInventoryValuation()
        {
            var valuation = await _productRepository.GetInventoryValuation();
            return Ok(valuation);
        }
    }
}
