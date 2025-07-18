namespace FullstackUsers.Application.Commands.Base
{
    public class BaseGetPagedCommand
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}
