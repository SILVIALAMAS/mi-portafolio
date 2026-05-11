using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Tracing;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Application.UseCases.User.Commands;
using TicketingAPI.Domain.Entities;

namespace TicketingAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {

            var result = await _userService.CreateAsync(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            var result = await _userService.UpdateAsync (command);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}