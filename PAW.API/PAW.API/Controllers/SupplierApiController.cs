using Microsoft.AspNetCore.Mvc;
using PAW.Business;   
using PAW.Models;    

namespace PAW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierApiController(ISupplierManager manager) : Controller
    {
        private readonly ISupplierManager _manager = manager;

        // GET ALL
        [HttpGet("all", Name = "GetAllSuppliers")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetAll()
        {
            var suppliers = await _manager.GetAllAsync();
            return Ok(suppliers);
        }

        // GET by ID
        [HttpGet("{id:int}", Name = "GetSupplierById")]
        public async Task<ActionResult<Supplier>> Get(int id)
        {
            var supplier = await _manager.GetByIdAsync(id);
            if (supplier == null) return NotFound();
            return Ok(supplier);
        }

        // CREATE
        [HttpPost("save", Name = "SaveSupplier")]
        public async Task<ActionResult<Supplier>> Create([FromBody] Supplier supplier)
        {
            if (supplier == null)
                return BadRequest("Supplier is null.");

            var created = await _manager.CreateAsync(supplier);
            if (created == null)
                return StatusCode(500, "Error creating supplier.");

            
            return CreatedAtAction(nameof(Get), new { id = created.SupplierId }, created);
        }

        // UPDATE
        [HttpPut("{id:int}", Name = "UpdateSupplier")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] Supplier supplier)
        {
            if (supplier == null || id != supplier.SupplierId)
                return BadRequest("ID mismatch or supplier is null.");

            var updated = await _manager.UpdateAsync(supplier);
            if (!updated) return NotFound();
            return Ok(updated);
        }

        // DELETE
        [HttpDelete("{id:int}", Name = "DeleteSupplier")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var deleted = await _manager.DeleteAsync(id);
            if (!deleted) return NotFound();
            return Ok(deleted);
        }
    }
}
