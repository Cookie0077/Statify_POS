using System.Text.Json.Serialization;

namespace Statifylib.Data.Models;

public abstract class SpotifyItem
{
    
    public int Id { get; set; }
    [JsonPropertyName("Name")]
    public string Name { get; set; }
    
    public virtual string Image { get; set; }
    public string URL { get; set; }

}