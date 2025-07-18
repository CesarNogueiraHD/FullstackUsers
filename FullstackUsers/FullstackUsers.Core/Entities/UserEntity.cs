namespace FullstackUsers.Core.Entities
{
    public class UserEntity(string email, string name, DateOnly? birth = null) : BaseEntity
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
        public string Password { get; private set; }
        public DateOnly? Birth { get; private set; } = birth;

        public UserEntity SetPassword(string password)
        {
            Password = password;
            return this;
        }
    }
}
