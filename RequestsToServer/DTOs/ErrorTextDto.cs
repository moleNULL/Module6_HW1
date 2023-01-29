using System.Text.Json.Serialization;

namespace RequestsToServer.DTOs.Responses
{
    public class ErrorTextDto
    {
        [JsonPropertyName("error")]
        public string? ErrorBody { get; set; }
    }
}