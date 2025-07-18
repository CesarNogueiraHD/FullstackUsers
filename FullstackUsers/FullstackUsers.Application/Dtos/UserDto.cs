using System.Xml.Linq;

namespace FullstackUsers.Application.Dtos
{
    public class UserDto(string name, string email, DateOnly? birth)
    {
        public required string Name { get; set; } = name;
        public required string Email { get; set; } = email;
        public DateOnly? Birth { get; set; } = birth;
    }
}
