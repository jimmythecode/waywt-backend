using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace waywt_backend.Models
{
    public class UserActionLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("id")]
        public string? Id { get; set; } // I want this to be a "valid 24 digit hex string", as I get an error when it isn't.

        [BsonElement("sessionId")]
        [JsonPropertyName("sessionId")]
        public string SessionId { get; set; } = null!;

        [BsonElement("secondsPassed")]
        [JsonPropertyName("secondsPassed")]
        public int SecondsPassed { get; set; } = 0;

        [BsonElement("localLogId")] // Describes the property name we're looking for from the database.
        [JsonPropertyName("localLogId")] // Describes the property name that we will convert to once we're about to send. Otherwise it would default to IpAddress (as per ASP.NET pascal case requirements)
        public int LocalLogId { get; set; } = 0;

        [BsonElement("localTimestamp")] 
        [JsonPropertyName("localTimestamp")]
        public string LocalTimestamp { get; set; } = null!;

        [BsonElement("action")]
        [JsonPropertyName("action")]
        public string Action { get; set; } = null!;
    }
}
