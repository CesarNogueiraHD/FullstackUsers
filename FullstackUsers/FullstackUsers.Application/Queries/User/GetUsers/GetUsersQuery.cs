using FullstackUsers.Application.Commands.Base;
using FullstackUsers.Application.Dtos;
using FullstackUsers.Core.Dtos;
using MediatR;

namespace FullstackUsers.Application.Queries.User.GetUsers
{
    public class GetUsersQuery : BaseGetPagedCommand, IRequest<ResultData<PagedResult<UserDto>>>;
}
