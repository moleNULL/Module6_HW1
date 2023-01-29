using System.Text.Json.Serialization;

namespace RequestsToServer.DTOs.Responses
{
    public class EmployeeDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("job")]
        public string Job { get; set; } = null!;

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; } = null!;

        [JsonPropertyName("updatedAt")]
        public string? UpdatedAt { get; set; }
    }
}