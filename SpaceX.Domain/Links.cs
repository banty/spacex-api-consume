using System.Text.Json.Serialization;

public class Links
{
    [JsonPropertyName("mission_patch")]
    public string? MissionPatch { get; set; }

    [JsonPropertyName("mission_patch_small")]
    public string? MissionPatchSmall { get; set; }

    [JsonPropertyName("reddit_campaign")]
    public string? RedditCampaign { get; set; }

    [JsonPropertyName("reddit_launch")]
    public string? RedditRaunch { get; set; }

    [JsonPropertyName("reddit_recovery")]
    public object? RedditRecovery { get; set; }

    [JsonPropertyName("reddit_media")]
    public string? RedditMedia { get; set; }

    public string? Presskit { get; set; }

    [JsonPropertyName("article_link")]
    public string? ArticleLink { get; set; }

    public string? Wikipedia { get; set; }

    [JsonPropertyName("video_link")]
    public string? VideoLink { get; set; }

    [JsonPropertyName("youtube_id")]
    public string? YoutubeId { get; set; }

    [JsonPropertyName("flickr_images")]
    public List<string>? FlickrImages { get; set; }
}




