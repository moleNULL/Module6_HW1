namespace RequestsToServer.Models
{
    public class LoginResult : Validation
    {
        public string Token { get; set; } = null!;
    }
}