using System.Text.Json.Serialization;

namespace PathOfExileWebApi.Contracts.Response
{
    public class SeasonModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("startAt")]
        public string StartAt { get; set; }

        [JsonPropertyName("endAt")]
        public string EndAt { get; set; }

        [JsonPropertyName("htmlId")]
        public string HtmlId { get; set; }
        
        [JsonPropertyName("htmlContent")]
        public string HtmlContent { get; set; }
    }
}
