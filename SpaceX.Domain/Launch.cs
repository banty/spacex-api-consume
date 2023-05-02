using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpaceX.Domain
{
    public class Launch
    {
        [JsonPropertyName("_id")]
        public string? Id { get; set; }

        [JsonPropertyName("flight_number")]
        public int FlightNumber { get; set; }

        [JsonPropertyName("mission_name")]
        public string? MissionName { get; set; }

        [JsonPropertyName("launch_year")]
        public string? LaunchYear { get; set; }

        [JsonPropertyName("launch_date_utc")]
        public DateTime? LaunchDateUtc { get; set; }

        [JsonPropertyName("is_tentative")]
        public bool? IsTentative { get; set; }

        [JsonPropertyName("rocket")]
        public Rocket? Rocket { get; set; }
     
        [JsonPropertyName("launch_site")]
        public LaunchSite? LaunchSite { get; set; }

        [JsonPropertyName("launch_success")]
        public bool? LaunchSuccess { get; set; }

        public Links? Links { get; set; }

        public string? Details { get; set; }

        public bool? Upcoming { get; set; }

        [JsonPropertyName("static_fire_date_utc")]
        public DateTime? StaticFireDateUtc { get; set; }

      
    }
}