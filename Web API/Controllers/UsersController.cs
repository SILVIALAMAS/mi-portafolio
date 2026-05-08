using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using TicketingAPI.Application.DTOs.User;
using TicketingAPI.Application.Services;
using TicketingAPI.Application.UseCases.User.Commands;using TicketingAPI.Application.UseCases.User.Queries;
using TicketingAPI.Domain.Entities;
using TicketingAPI.Infrastructure;
using TicketingAPI.Application.UseCases.User.Handlers;
namespace TicketingAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
       // private readonly UserService _service;//AppDbContext _context;
        private readonly GetUsersHandler _handlerGet;private readonly CreateUserHandler _handler;
        public UsersController(CreateUserHandler handler,GetUsersHandler handlerGet)//AppDbContext context)
        {
            _handler = handler;
            _handlerGet = handlerGet;
        }

        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var users = await _handlerGet.Execute();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserDto dto)
        {
            var command = new CreateUserCommand
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };

            await _handler.Execute(command);

            return Ok();
        }
    }
}