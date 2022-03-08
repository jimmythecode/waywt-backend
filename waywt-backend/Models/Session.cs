using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace waywt_backend.Models
{
    public class Session
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("device")] // Describes the property name we're looking for from the database.
        [JsonPropertyName("Device")] // Describes the property name that we will convert to once we're about to send. Otherwise it would default to IpAddress (as per ASP.NET pascal case requirements)
        public DeviceData Device { get; set; } = null!;

        [BsonElement("location")]
        [JsonPropertyName("Location")]
        public LocationData Location { get; set; } = null!;

        [BsonElement("geoLocation")]
        [JsonPropertyName("GeoLocation")]
        public GeolocationData Geolocation { get; set; } = null!;

        public class LocationData
        {
            [BsonElement("IPv4")] // Describes the property name we're looking for from the database.
            [JsonPropertyName("IPv4")] // Describes the property name that we will convert to once we're about to send. Otherwise it would default to IpAddress (as per ASP.NET pascal case requirements)
            public string IPv4 { get; set; } = null!;

            [BsonElement("city")]
            [JsonPropertyName("City")]
            public string City { get; set; } = null!;

            [BsonElement("country_code")]
            [JsonPropertyName("Country_code")]
            public string Country_code { get; set; } = null!;

            [BsonElement("country_name")]
            [JsonPropertyName("Country_name")]
            public string Country_name { get; set; } = null!;

            [BsonElement("latitude")]
            [JsonPropertyName("Latitude")]
            public double Latitude { get; set; } = 0!;

            [BsonElement("longitude")]
            [JsonPropertyName("Longitude")]
            public double Longitude { get; set; } = 0!;

            [BsonElement("postal")]
            [JsonPropertyName("Postal")]
            public string Postal { get; set; } = null!;

            [BsonElement("state")]
            [JsonPropertyName("State")]
            public string State { get; set; } = null!;
        }
        public class DeviceData
        {
            [BsonElement("browserName")] // Describes the property name we're looking for from the database.
            [JsonPropertyName("BrowserName")] // Describes the property name that we will convert to once we're about to send. Otherwise it would default to IpAddress (as per ASP.NET pascal case requirements)
            public string BrowserName { get; set; } = null!;

            [BsonElement("deviceType")]
            [JsonPropertyName("DeviceType")]
            public string DeviceType { get; set; } = null!;

            [BsonElement("getUA")]
            [JsonPropertyName("GetUA")]
            public string getUA { get; set; } = null!;

            [BsonElement("mobileModel")]
            [JsonPropertyName("MobileModel")]
            public string MobileModel { get; set; } = null!;

            [BsonElement("mobileVendor")]
            [JsonPropertyName("MobileVendor")]
            public string MobileVendor { get; set; } = null!;

            [BsonElement("osName")]
            [JsonPropertyName("OsName")]
            public string OsName { get; set; } = null!;
        }

        public class GeolocationData
        {
            [BsonElement("ip")]
            [JsonPropertyName("Ip")]
            public string Ip { get; set; } = null!;

            public GeolocationData()
            {
            }
        }

        public class Incoming
        {
            [BsonElement("device")] // Describes the property name we're looking for from the database.
            [JsonPropertyName("Device")] // Describes the property name that we will convert to once we're about to send. Otherwise it would default to IpAddress (as per ASP.NET pascal case requirements)
            public DeviceData Device { get; set; } = null!;

            [BsonElement("location")]
            [JsonPropertyName("Location")]
            public LocationData Location { get; set; } = null!;

            [BsonElement("geoLocation")]
            [JsonPropertyName("GeoLocation")]
            public GeolocationData Geolocation { get; set; } = null!;
        }
    }

}
