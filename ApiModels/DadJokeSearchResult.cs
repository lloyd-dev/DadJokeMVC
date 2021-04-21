using System.Text.Json.Serialization;

namespace DadJokeMVC.ApiModels
{
    public class DadJokeSearchResult
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("joke")]
        public string Joke { get; set; }
    }
}
