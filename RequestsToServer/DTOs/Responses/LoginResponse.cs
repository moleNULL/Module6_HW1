using System.Text.Json.Serialization;

namespace RequestsToServer.DTOs.Responses
{
    public class LoginResponse : ErrorTextDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}