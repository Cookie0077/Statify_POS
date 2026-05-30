using System.Text.Json.Serialization;
using Statifylib.Data.Models;

namespace StatifyLib.Data.Models;

public class TrackRecord: SpotifyItem
{
    [JsonPropertyName("Timestamp")]
    public DateTime LastPlayed { get; set; }
    
    [JsonPropertyName("Duration")]
    public int Duration { get; set; }
    
    public int UID { get; set; }
    
    [JsonPropertyName("Track_Name")]
    public string Name { get; set; }
    
    [JsonPropertyName("Track_Image")]
    public string Image { get; set; }
    
    [JsonPropertyName("Artist_Name")]
    public string Artist { get; set; }
    
    // TODO: Implement the Playcount in the Backend 
    [JsonIgnore]
    public int PlayCount { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Artist}";
    }
}