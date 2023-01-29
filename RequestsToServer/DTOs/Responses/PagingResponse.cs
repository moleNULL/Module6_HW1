using System.Text.Json.Serialization;

namespace RequestsToServer.DTOs.Responses
{
    public class PagingResponse<T>
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("total_page")]
        public int TotalPage { get; set; }

        [JsonPropertyName("data")]
        public T? Data { get; set; }

        [JsonPropertyName("support")]
        public SupportDto? Support { get; set; }
    }
}