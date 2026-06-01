using System.Text.Json.Serialization;

namespace Statifylib.Data.Models;

public class Playlist: SpotifyItem
{
    public int FollowerCount { get; set; }
    public string Owner { get; set; }

    /* TODO: Implement in API
   [JsonPropertyName("Playlist_image")]
   public override string Image { get; set; }
   */
    public Playlist () {}

    public override string ToString()
    {
        return $"{Name}";
    }
}