using Academy2025.Repositories;
using Academy2025.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Academy2025.Dtos;
using Academy2025.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAsync()
        {
            return await _userService.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task <ActionResult<UserDto>> GetAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            return user == null ? NotFound() : user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> PostAnysc([FromBody] UserDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.CreateAsync(data);

            return NoContent();

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] UserDto data)
        {
            var user = await _userService.UpdateAsync(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task <ActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);

            return result ? NoContent() : NotFound();
        }
    }
}