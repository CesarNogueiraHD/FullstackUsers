using AutoMapper;
using FullstackUsers.Application.Dtos;
using FullstackUsers.Core.Dtos;
using FullstackUsers.Core.Services;
using FullstackUsers.Infra.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace FullstackUsers.Application.Commands.Auth.Login
{
    public class Handler(ApplicationDbContext context, IMapper mapper, TokenService tokenService)
        : IRequestHandler<LoginCommand, ResultData<LoginDto>>
    {
        public async Task<ResultData<LoginDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var userSearched = await context.Users
                .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

            if (userSearched == null)
                return ResultData<LoginDto>.Failure("User not found.");

            var passwordIsCorrect = Verify(request.Password, userSearched.Password);

            if (!passwordIsCorrect)
                return ResultData<LoginDto>.Failure("The password is incorrect.");

            var token = tokenService.GenerateToken(userSearched);

            return ResultData<LoginDto>.Success(new LoginDto(token));

        }
    }
}
