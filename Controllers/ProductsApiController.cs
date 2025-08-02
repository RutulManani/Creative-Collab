using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftelleCMSbackend.Data;
using GiftelleCMSbackend.Models;
using GiftelleCMSbackend.DTOs;

namespace GiftelleCMSbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products = await _context.Products
                .Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    VendorId = p.VendorId
                }).ToListAsync();

            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            var dto = new ProductDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                VendorId = product.VendorId
            };

            return Ok(dto);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct(ProductDTO productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                VendorId = productDto.VendorId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            productDto.ProductId = product.ProductId;

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, productDto);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO productDto)
        {
            if (id != productDto.ProductId) return BadRequest();

            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.VendorId = productDto.VendorId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
