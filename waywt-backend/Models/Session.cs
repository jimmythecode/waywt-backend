using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace waywt_backend.Models
{
    public class Session
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [BsonElement("deviceDataObject")] // Describes the property name we're looking for from the database.
        [JsonPropertyName("deviceDataObject")] // Describes the property name that we will convert to once we're about to send. Otherwise it would default to IpAddress (as per ASP.NET pascal case requirements)
        public DeviceData DeviceDataObject { get; set; } = null!;

        [BsonElement("geolocationObject")]
        [JsonPropertyName("geolocationObject")]
        public LocationData GeolocationObject { get; set; } = null!;

        [BsonElement("ipObject")]
        [JsonPropertyName("ipObject")]
        public IpData IpObject { get; set; } = null!;

        public class LocationData
        {
            [BsonElement("IPv4")] // Describes the property name we're looking for from the database.
            [JsonPropertyName("iPv4")] // Describes the property name that we will convert to once we're about to send. Otherwise it would default to IpAddress (as per ASP.NET pascal case requirements)
            public string IPv4 { get; set; } = null!;

            [BsonElement("city")]
            [JsonPropertyName("city")]
            public string City { get; set; } = null!;

            [BsonElement("country_code")]
            [JsonPropertyName("country_code")]
            public string Country_code { get; set; } = null!;

            [BsonElement("country_name")]
            [JsonPropertyName("country_name")]
            public string Country_name { get; set; } = null!;

            [BsonElement("latitude")]
            [JsonPropertyName("latitude")]
            public double Latitude { get; set; } = 0!;

            [BsonElement("longitude")]
            [JsonPropertyName("longitude")]
            public double Longitude { get; set; } = 0!;

            [BsonElement("postal")]
            [JsonPropertyName("postal")]
            public string Postal { get; set; } = null!;

            [BsonElement("state")]
            [JsonPropertyName("state")]
            public string State { get; set; } = null!;
        }
        public class DeviceData
        {
            [BsonElement("browserName")] // Describes the property name we're looking for from the database.
            [JsonPropertyName("browserName")] // Describes the property name that we will convert to once we're about to send. Otherwise it would default to IpAddress (as per ASP.NET pascal case requirements)
            public string BrowserName { get; set; } = null!;

            [BsonElement("deviceType")]
            [JsonPropertyName("deviceType")]
            public string DeviceType { get; set; } = null!;

            [BsonElement("getUA")]
            [JsonPropertyName("getUA")]
            public string GetUA { get; set; } = null!;

            [BsonElement("mobileModel")]
            [JsonPropertyName("mobileModel")]
            public string MobileModel { get; set; } = null!;

            [BsonElement("mobileVendor")]
            [JsonPropertyName("mobileVendor")]
            public string MobileVendor { get; set; } = null!;

            [BsonElement("osName")]
            [JsonPropertyName("osName")]
            public string OsName { get; set; } = null!;
        }

        public class IpData
        {
            [BsonElement("ip")]
            [JsonPropertyName("ip")]
            public string Ip { get; set; } = null!;

            public IpData()
            {
            }
        }

        public class Incoming
        {
            [BsonElement("deviceDataObject")] // Describes the property name we're looking for from the database.
            [JsonPropertyName("deviceDataObject")]
            public DeviceData DeviceDataObject { get; set; } = null!;

            [BsonElement("geolocationObject")]
            [JsonPropertyName("geolocationObject")]
            public LocationData GeolocationObject { get; set; } = null!;

            [BsonElement("ipObject")]
            [JsonPropertyName("ipObject")]
            public IpData IpObject { get; set; } = null!;
        }
    }

}
