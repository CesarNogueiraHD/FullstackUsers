using AutoMapper;
using FullstackUsers.Application.Commands.User.CreateUser;
using FullstackUsers.Application.Dtos;
using FullstackUsers.Core.Dtos;
using FullstackUsers.Core.Entities;

namespace FullstackUsers.Application.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap(typeof(ResultData<>), typeof(ResultData<>));

            CreateMap<CreateUserCommand, UserEntity>();
            CreateMap<UserEntity, UserCreatedDto>();
            CreateMap<UserEntity, UserDto>();
        }
    }
}
