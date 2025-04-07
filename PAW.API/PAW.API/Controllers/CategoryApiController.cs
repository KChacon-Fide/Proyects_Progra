using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;

namespace PAW.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CategoryApiController(ICategoryManager categoryManager) : Controller
    {
        private readonly ICategoryManager _categoryManager = categoryManager;

        [HttpGet("all")]
        public async Task<ActionResult<List<Category>>> ReadAllAsync()
        {
            var result = await _categoryManager.ReadAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> GetByIdAsync(int id)
        {
            var category = await _categoryManager.GetByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost("save")]
        public async Task<ActionResult<Category>> CreateAsync([FromBody] Category entity)
        {
            var created = await _categoryManager.CreateAsync(entity);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = created.CategoryId }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> UpdateAsync(int id, [FromBody] Category entity)
        {
            if (id != entity.CategoryId) return BadRequest("ID mismatch");

            var updated = await _categoryManager.UpdateAsync(entity);
            if (!updated) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteAsync(int id)
        {
            var deleted = await _categoryManager.DeleteAsync(id);
            if (!deleted) return NotFound();
            return Ok(deleted);
        }
    }
}
