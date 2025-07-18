using AutoMapper;
using FullstackUsers.Application.Dtos;
using FullstackUsers.Core.Dtos;
using FullstackUsers.Infra.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FullstackUsers.Application.Queries.User.GetUsers
{
    public class Handler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<GetUsersQuery, ResultData<PagedResult<UserDto>>>
    {
        public async Task<ResultData<PagedResult<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var query = context.Users
                .AsNoTracking()
                .AsQueryable();

            var totalItems = await query.CountAsync(cancellationToken);
            var items = await query
                .Skip(request.Size * (request.Page - 1))
                .Take(request.Size)
                .Select(u => mapper.Map<UserDto>(u))
                .ToListAsync(cancellationToken);

            return ResultData<PagedResult<UserDto>>.Success(PagedResult<UserDto>.ReturnPaged(items, totalItems,
                (int)Math.Ceiling((decimal)totalItems / request.Size), request.Page));
        }
    }
}
