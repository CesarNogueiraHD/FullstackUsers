using FullstackUsers.Application.Commands.Auth.Login;
using FullstackUsers.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FullstackUsers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator bus) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<LoginDto>> Login([FromBody] LoginCommand command)
        {
            try
            {
                var result = await bus.Send(command);
                return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
