using System.Text.Json.Serialization;

namespace Statifylib.Data.Models;

public class Artist: SpotifyItem
{
    public int Playtime { get; set; }
   
    public Artist () {}

    public override string ToString()
    {
        return $"{Name}";
    }
}