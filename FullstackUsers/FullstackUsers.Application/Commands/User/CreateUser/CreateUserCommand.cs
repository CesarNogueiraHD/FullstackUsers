using FullstackUsers.Application.Dtos;
using FullstackUsers.Core.Dtos;
using MediatR;

namespace FullstackUsers.Application.Commands.User.CreateUser
{
    public class CreateUserCommand(string email, string password, string passwordConfirmation, string name, DateOnly? birth = null)
        : IRequest<ResultData<UserCreatedDto>>
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public string Password { get; private set; } = password;
        public string PasswordConfirmation { get; private set; } = passwordConfirmation;
        public DateOnly? Birth { get; private set; } = birth;
    }
}
