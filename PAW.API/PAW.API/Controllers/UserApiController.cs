using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;

namespace PAW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserApiController(IUserManager manager) : Controller
    {
        private readonly IUserManager _manager = manager;

        [HttpGet("all", Name = "GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _manager.GetAllAsync();
            return Ok(users);
        }

        // GET by ID
        [HttpGet("{id:int}", Name = "GetUserById")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _manager.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // CREATE
        [HttpPost("save", Name = "SaveUser")]
        public async Task<ActionResult<User>> Create([FromBody] User user)
        {
            if (user == null)
                return BadRequest("User is null.");

            var created = await _manager.CreateAsync(user);
            if (created == null)
                return StatusCode(500, "Error creating user.");

            
            return CreatedAtAction(nameof(Get), new { id = created.UserId }, created);
        }

        // UPDATE
        [HttpPut("{id:int}", Name = "UpdateUser")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] User user)
        {
            if (user == null || id != user.UserId)
                return BadRequest("ID mismatch or user is null.");

            var updated = await _manager.UpdateAsync(user);
            if (!updated) return NotFound();
            return Ok(updated);
        }

        // DELETE
        [HttpDelete("{id:int}", Name = "DeleteUser")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var deleted = await _manager.DeleteAsync(id);
            if (!deleted) return NotFound();
            return Ok(deleted);
        }
    }
}
