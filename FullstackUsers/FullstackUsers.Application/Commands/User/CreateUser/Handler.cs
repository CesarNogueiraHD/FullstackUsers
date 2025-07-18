using AutoMapper;
using FullstackUsers.Application.Dtos;
using FullstackUsers.Core.Dtos;
using FullstackUsers.Core.Entities;
using FullstackUsers.Infra.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace FullstackUsers.Application.Commands.User.CreateUser
{
    public class Handler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<CreateUserCommand, ResultData<UserCreatedDto>>
    {
        public async Task<ResultData<UserCreatedDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userAlreadyExists = await context.Users.AnyAsync(x => x.Email == request.Email, cancellationToken);
            if (userAlreadyExists)
                return ResultData<UserCreatedDto>.Failure("The email already is used.");

            var passwordConfirmationIsMatching = request.Password == request.PasswordConfirmation;
            if (!passwordConfirmationIsMatching)
                return ResultData<UserCreatedDto>.Failure("The password confirmation does't match.");

            var userEntity = mapper.Map<UserEntity>(request);
            var hashedPassword = HashPassword(request.Password, 12);
            userEntity.SetPassword(hashedPassword);

            await context.AddAsync(userEntity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            var userCreated = mapper.Map<UserCreatedDto>(userEntity);
            return ResultData<UserCreatedDto>.Success(userCreated);
        }
    }
}
