using FullstackUsers.Application.Commands.User.CreateUser;
using FullstackUsers.Application.Dtos;
using FullstackUsers.Application.Queries.User.GetUsers;
using FullstackUsers.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullstackUsers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator bus) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllAsync([FromQuery] GetUsersQuery query)
        {
            try
            {
                var result = await bus.Send(query);
                return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> PostAsync([FromBody] CreateUserCommand command)
        {
            try
            {
                var result = await bus.Send(command);
                return result.IsSuccess ? Created($"/Users/{result.Data.Id}", result.Data) : BadRequest(result.Error);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
