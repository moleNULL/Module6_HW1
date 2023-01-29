using System.Text.Json.Serialization;

namespace RequestsToServer.DTOs.Responses
{
    public class ResourceDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; } = null!;

        [JsonPropertyName("pantone_value")]
        public string PantoneValue { get; set; } = null!;
    }
}