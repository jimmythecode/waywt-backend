using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace waywt_backend.Models
{
    public class UserActionLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("localLogId")] // Describes the property name we're looking for from the database.
        [JsonPropertyName("LocalLogId")] // Describes the property name that we will convert to once we're about to send. Otherwise it would default to IpAddress (as per ASP.NET pascal case requirements)
        public int LocalLogId { get; set; } = 0;

        [BsonElement("localTimestamp")] 
        [JsonPropertyName("LocalTimestamp")]
        public string LocalTimestamp { get; set; } = null!;

        [BsonElement("action")]
        [JsonPropertyName("Action")]
        public string Action { get; set; } = null!;
    }
}
