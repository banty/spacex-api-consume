using System.Text.Json.Serialization;

public class LaunchSite
{
    [JsonPropertyName("site_name")]
    public string? SiteName { get; set; }

    [JsonPropertyName("site_name_long")]
    public string? SiteNameLong { get; set; }
}




