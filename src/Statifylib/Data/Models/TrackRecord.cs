#region

using System.Text.Json.Serialization;
using Statifylib.Data.Models;

#endregion

namespace StatifyLib.Data.Models;

public class TrackRecord : SpotifyItem
{

    [JsonPropertyName("Timestamp")] public DateTime LastPlayed { get; set; }


    [JsonPropertyName("Duration")] public int Duration { get; set; }

    public int UID { get; set; }

    [JsonPropertyName("Track_Name")] public string Name { get; set; }


    [JsonPropertyName("Artist_Name")] public string Artist { get; set; }

    [JsonPropertyName("Track_image")] public override string Image { get; set; }
    [JsonPropertyName("Playcount")] public int PlayCount { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Artist}";
    }
}