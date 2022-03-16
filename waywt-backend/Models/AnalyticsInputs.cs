using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace waywt_backend.Models
{
    public class AnalyticsInputs
    {
        [BsonElement("logOfUserActions")]
        [JsonPropertyName("logOfUserActions")]
        public IEnumerable<UserActionLog> LogOfUserActions { get; set; } = null!;
    }
}
