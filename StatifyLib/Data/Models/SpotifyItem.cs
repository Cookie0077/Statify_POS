using System.Text.Json.Serialization;

namespace Statifylib.Data.Models;

public abstract class SpotifyItem
{
    
    public int Id { get; set; }
    [JsonPropertyName("Name")]
    public string Name { get; set; }
}