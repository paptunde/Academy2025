﻿using Academy2025.Repositories;
using Academy2025.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Academy2025.Dtos;
using Academy2025.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BCrypt.Net;

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
        [Authorize(Policy ="AdminOnlyPolicy")]
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAsync()
        {
            return await _userService.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task <ActionResult<UserDto>> GetAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            return user == null ? NotFound() : user;
        }

        // POST api/<UsersController>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> PostAnysc([FromBody] UserDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            data.HashedPassword = BCrypt.Net.BCrypt.HashPassword(data.Password);
            await _userService.CreateAsync(data);

            return NoContent();

        }

        // PUT api/<UsersController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] UserDto data)
        {
            var user = await _userService.UpdateAsync(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task <ActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);

            return result ? NoContent() : NotFound();
        }
    }
}