using System.Text.Json.Serialization;

namespace Statifylib.Data.Models;

public class Track: SpotifyItem
{
    public string Image { get; set; }
    
    [JsonIgnore]
    public string Artist { get; set; }
    [JsonIgnore]
    public int Duration { get; set; }
    [JsonIgnore]
    public DateTime LastPlayed { get; set; }
    [JsonIgnore]
    public int PlayCount { get; set; }
    
    
    public Track () {}

    public Track(int id, string name)
    {
        Id = id;
        Name = name;
    }


    public override string ToString()
    {
        return $"{Name}";
    }
}