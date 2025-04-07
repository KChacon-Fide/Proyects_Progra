using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;

namespace PAW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductApiController(IProductManager manager) : Controller
    {
        private readonly IProductManager _manager = manager;

        // GET by ID
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _manager.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // GET all
        [HttpGet("all", Name = "GetAllProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _manager.GetAllAsync();
            return Ok(products);
        }

        // CREATE
        [HttpPost("save", Name = "SaveProduct")]
        public async Task<ActionResult<Product>> Save([FromBody] Product product)
        {
            if (product == null)
                return BadRequest("Product is null.");

            var created = await _manager.CreateAsync(product);
            if (created == null)
                return StatusCode(500, "Error creating product.");

           
            return CreatedAtAction(nameof(Get), new { id = created.ProductId }, created);
        }

        // UPDATE
        [HttpPut("{id}", Name = "UpdateProduct")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] Product product)
        {
            if (product == null || id != product.ProductId)
                return BadRequest("ID mismatch or product is null.");

            var updated = await _manager.UpdateAsync(product);
            if (!updated)
                return NotFound(); 

            return Ok(updated);
        }

        // DELETE
        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var deleted = await _manager.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return Ok(deleted);
        }
    }
}
