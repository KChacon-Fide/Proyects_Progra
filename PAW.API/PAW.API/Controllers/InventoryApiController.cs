using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;

namespace PAW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryApiController(IInventoryManager inventorymanager) : Controller
    {
        private readonly IInventoryManager _inventorymanager = inventorymanager;

        // GET ALL
        [HttpGet("all", Name = "GetAllInventories")]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetAll()
        {
            var items = await _inventorymanager.GetAllAsync();
            return Ok(items);
        }

        // GET by ID
        [HttpGet("{id:int}", Name = "GetInventoryById")]
        public async Task<ActionResult<Inventory>> Get(int id)
        {
            var item = await _inventorymanager.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // CREATE
        [HttpPost("save", Name = "SaveInventory")]
        public async Task<ActionResult<Inventory>> Create([FromBody] Inventory inventory)
        {
            if (inventory == null)
                return BadRequest("Inventory is null.");

            var created = await _inventorymanager.CreateAsync(inventory);
            if (created == null)
                return StatusCode(500, "Error creating inventory.");

            return CreatedAtAction(nameof(Get), new { id = created.InventoryId }, created);
        }

        // UPDATE
        [HttpPut("{id:int}", Name = "UpdateInventory")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] Inventory inventory)
        {
            if (inventory == null || id != inventory.InventoryId)
                return BadRequest("ID mismatch or inventory is null.");

            var updated = await _inventorymanager.UpdateAsync(inventory);
            if (!updated) return NotFound();
            return Ok(updated);
        }

        // DELETE
        [HttpDelete("{id:int}", Name = "DeleteInventory")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var deleted = await _inventorymanager.DeleteAsync(id);
            if (!deleted) return NotFound();
            return Ok(deleted);
        }
    }
}
