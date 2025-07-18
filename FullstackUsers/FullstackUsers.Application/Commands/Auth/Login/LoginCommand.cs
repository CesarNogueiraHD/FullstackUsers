using FullstackUsers.Application.Dtos;
using FullstackUsers.Core.Dtos;
using MediatR;

namespace FullstackUsers.Application.Commands.Auth.Login
{
    public class LoginCommand(string email, string password) : IRequest<ResultData<LoginDto>>
    {
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
    }
}
