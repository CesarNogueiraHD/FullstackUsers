namespace FullstackUsers.Application.Dtos
{
    public class LoginDto(string accessToken)
    {
        public string AccessToken { get; set; } = accessToken;
    }
}
