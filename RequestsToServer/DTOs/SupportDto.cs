using System.Text.Json.Serialization;

namespace RequestsToServer.DTOs.Responses
{
    public class SupportDto
    {
        [JsonPropertyName("url")]
        public string Url { get; set; } = null!;

        [JsonPropertyName("text")]
        public string Text { get; set; } = null!;
    }
}