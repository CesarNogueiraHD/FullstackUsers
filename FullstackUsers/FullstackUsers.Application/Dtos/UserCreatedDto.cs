using System.Xml.Linq;

namespace FullstackUsers.Application.Dtos
{
    public class UserCreatedDto(Guid id, string email, string name, DateOnly? birth = null)
    {
        public Guid Id { get; private set; } = id;
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public DateOnly? Birth { get; private set; } = birth;
    }
}
