using FullstackUsers.Api.Controllers;
using FullstackUsers.Application.Dtos;
using FullstackUsers.Application.Queries.User.GetUsers;
using FullstackUsers.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;

namespace FullstackUsers.Tests
{
    public class GlobalTests
    {
        [Fact]
        public async Task When_HasUserCreated_Should_ReturnUserListWithUser()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new UsersController(mockMediator.Object);

            var user01 = new UserDto("User 01", "user01@test.com", null);
            var user02 = new UserDto("User 02", "user02@test.com", null);
            var user03 = new UserDto("User 03", "user03@test.com", null);
            var usersList = new List<UserDto> { user01, user02, user03 };

            mockMediator
                .Setup(mediator => mediator.Send(It.IsAny<GetUsersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(ResultData<PagedResult<UserDto>>.Success(new PagedResult<UserDto>(usersList)));

            // Act
            var result = await controller.GetAllAsync(new GetUsersQuery
            {
                Page = 1,
                Size = 10
            });

            // Asserts
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, okResult.StatusCode);
            var returnValue = Assert.IsAssignableFrom<PagedResult<UserDto>>(okResult.Value);
            Assert.Equal(3, returnValue.Items.Count);
            Assert.Equal("User 01", returnValue.Items[0].Name);
        }
    }
}