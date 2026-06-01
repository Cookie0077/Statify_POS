using System.Text.Json.Serialization;

namespace Statifylib.Data.Models;

public class Artist: SpotifyItem
{
    public int FollowerCount { get; set; }
   /* TODO: Implement in API
    [JsonPropertyName("Artist_image")] 
    public override string Image { get; set; }
    */
    public Artist () {}
    
    public Artist (int id, string name) 
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}