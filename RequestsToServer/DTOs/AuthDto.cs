using System.Text.Json.Serialization;

namespace RequestsToServer.DTOs.Responses
{
    public class AuthDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;

        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;
    }
}