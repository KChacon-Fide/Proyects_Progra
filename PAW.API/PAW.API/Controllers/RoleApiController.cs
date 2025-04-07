using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PAW.Business;   
using PAW.Models;    

namespace PAW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleApiController(IRoleManager rolemanager) : Controller
    {
        private readonly IRoleManager _rolemanager = rolemanager;

        // GET ALL
        [HttpGet("all", Name = "GetAllRoles")]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            var roles = await _rolemanager.GetAllAsync();
            return Ok(roles);
        }

        // GET by ID
        [HttpGet("{id:int}", Name = "GetRoleById")]
        public async Task<ActionResult<Role>> Get(int id)
        {
            var role = await _rolemanager.GetByIdAsync(id);
            if (role == null) return NotFound();
            return Ok(role);
        }

        // CREATE
        [HttpPost("save", Name = "SaveRole")]
        public async Task<ActionResult<Role>> Create([FromBody] Role role)
        {
            if (role == null)
                return BadRequest("Role is null.");

            var created = await _rolemanager.CreateAsync(role);
            if (created == null)
                return StatusCode(500, "Error creating role.");

            
            return CreatedAtAction(nameof(Get), new { id = created.RoleId }, created);
        }

        // UPDATE
        [HttpPut("{id:int}", Name = "UpdateRole")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] Role role)
        {
            if (role == null || id != role.RoleId)
                return BadRequest("ID mismatch or role is null.");

            var updated = await _rolemanager.UpdateAsync(role);
            if (!updated) return NotFound();
            return Ok(updated);
        }

        // DELETE
        [HttpDelete("{id:int}", Name = "DeleteRole")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var deleted = await _rolemanager.DeleteAsync(id);
            if (!deleted) return NotFound();
            return Ok(deleted);
        }
    }
}
